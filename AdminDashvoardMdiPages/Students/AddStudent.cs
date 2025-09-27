using RegistrationForm.AdminDashvoardMdiPages.LogsFolder;
using RegistrationForm.AdminDashvoardMdiPages.Subjects.SubjectData;
using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class AddStudent : Form
    {
        string connectionString = ConnectionString.conn;

        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                (this.ClientSize.Width / 2) - (panel1.Width / 2),
                (this.ClientSize.Height / 2) - (panel1.Height / 2) 
            );

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            bool isValid = true;

            foreach (Control control in GetAllControls(this))
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        message += "Credentials must be entered!";
                        isValid = false;
                    }
                    else
                    {
                        string hashpassword = PasswordEncryption.SHA256Hash(txtPassword.Text);

                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            SqlCommand cmd = new SqlCommand("SP_Register", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("RolePrefix", "ST");
                            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("Status", "Active");
                            cmd.Parameters.AddWithValue("Username", TxtUsername.Text);
                            cmd.Parameters.AddWithValue("Password", hashpassword);
                            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("Phone", Convert.ToInt32(txtPhone.Text));
                            cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("Age", Convert.ToInt32(txtAge.Text));
                            cmd.Parameters.AddWithValue("EnrollmentDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("TermName", cmbTerm.Text);
                            cmd.Parameters.AddWithValue("CourseName", cmbCourses.Text);
                            cmd.Parameters.AddWithValue("DepartmentName", DBNull.Value); 
                            cmd.Parameters.AddWithValue("HireDate", DBNull.Value);       

                            if (radFemale.Checked)
                            {
                                cmd.Parameters.AddWithValue("Gender", radFemale.Text);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("Gender", radMale.Text);
                            }


                            conn.Open();
                            cmd.ExecuteNonQuery();
                            Log.Logss(User.Name, "Adding Student");

                            MessageBox.Show("Registration Done!", "Successfull", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    break;
                }
            }
            if (!isValid)
            {
                MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private IEnumerable<Control> GetAllControls(Control container)
        {
            foreach (Control ctrl in container.Controls)
            {
                foreach (Control child in GetAllControls(ctrl))
                {
                    yield return child;
                }
                yield return ctrl;
            }
        }

        private void cmbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbTerm.SelectedIndex == 0)
            {
                cmbDept.Items.Add("College of Computer Science");
                cmbDept.Items.Add("College of Busines and Management");
                cmbDept.Items.Add("College of Nursing");
                cmbDept.Items.Add("College of Education");
                cmbDept.Items.Add("College of Criminal Justice");
            }
            else
            {
                cmbDept.Items.Clear();
            }
           
        }

        public void DisplayCourses(int departmentId)
        {
            var repos = new SubjectRepos();
            var courses = repos.GetCoursesByDepartment(departmentId);

            DataTable dt = new DataTable();
            dt.Columns.Add("CourseName", typeof(string));

            foreach (var course in courses)
            {
                var row = dt.NewRow();
                row["CourseName"] = course.CourseName;
                dt.Rows.Add(row);
            }

            cmbCourses.DataSource = dt;
            cmbCourses.DisplayMember = "CourseName";
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            int r = cmbDept.SelectedIndex + 1;

            DisplayCourses(r);
        }
    }
}
