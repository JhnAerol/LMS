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

namespace RegistrationForm.MdiPages
{
    public partial class AddTeacher : Form
    {
        string connectionString = ConnectionString.conn;

        public AddTeacher()
        {
            InitializeComponent();
        }

        private void AddTeacher_Resize(object sender, EventArgs e)
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
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string hashpassword = PasswordEncryption.SHA256Hash(txtPassword.Text);

                            SqlCommand cmd = new SqlCommand("SP_Register", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("RolePrefix", "TH");
                            cmd.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                            cmd.Parameters.AddWithValue("Address", txtAddress.Text);
                            cmd.Parameters.AddWithValue("Status", cmbStatus.Text);
                            cmd.Parameters.AddWithValue("Username", TxtUsername.Text);
                            cmd.Parameters.AddWithValue("Password", hashpassword);
                            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("Phone", Convert.ToInt32(txtPhone.Text));
                            cmd.Parameters.AddWithValue("LastName", txtLastName.Text);
                            cmd.Parameters.AddWithValue("Age", Convert.ToInt32(txtAge.Text));
                            cmd.Parameters.AddWithValue("HireDate", DateTime.Now);
                            cmd.Parameters.AddWithValue("DepartmentName", cmbDepartments.Text);
                            cmd.Parameters.AddWithValue("@EnrollmentDate", DBNull.Value);
                            cmd.Parameters.AddWithValue("TermName", DBNull.Value);
                            cmd.Parameters.AddWithValue("CourseName", DBNull.Value);

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

                            MessageBox.Show("Registration Done!");
                            new LoginForm().Show();
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
    }
}
