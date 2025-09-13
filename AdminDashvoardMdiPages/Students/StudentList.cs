using RegistrationForm.AdminDashvoardMdiPages.Students.StudentData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Students
{
    public partial class StudentList : Form
    {
        public StudentList()
        {
            InitializeComponent();
            ReadStudents();
        }

        private void StudentList_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                (this.ClientSize.Width / 2) - (panel1.Width / 2),
                (this.ClientSize.Height / 2) - (panel1.Height / 2)
            );
        }

        public void ReadStudents()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Enrollment Date");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");
            dt.Columns.Add("Status");
            dt.Columns.Add("Role Code");

            var repos = new StudentRepos();
            var students = repos.GetStudents();

            foreach ( var student in students )
            {
                var row = dt.NewRow();

                row["ID"] = Convert.ToInt32(student.Id);
                row["Enrollment Date"] = Convert.ToDateTime(student.EnrollmentDate);
                row["First Name"] = student.Firstname;
                row["Last Name"] = student.Lastname;
                row["Age"] = Convert.ToInt32(student.Age);
                row["Gender"] = student.Gender;
                row["Phone"] = Convert.ToInt32(student.Phone);
                row["Address"] = student.Address;
                row["Email"] = student.Email;
                row["Status"] = student.Status;
                row["Role Code"] = student.RolesCode;

                dt.Rows.Add(row);
            }

            dgvStudents.DataSource = dt;
        }
    }
}
