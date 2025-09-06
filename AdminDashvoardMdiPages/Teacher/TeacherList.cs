using RegistrationForm.AdminDashvoardMdiPages.Students.StudentData;
using RegistrationForm.AdminDashvoardMdiPages.Teacher.TeacherData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Teacher
{
    public partial class TeacherList : Form
    {
        public TeacherList()
        {
            InitializeComponent();
            ReadTeacher();
        }

        public void ReadTeacher()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");
            dt.Columns.Add("Status");
            dt.Columns.Add("Role Code");

            var repos = new TeacherRepos();
            var teachers = repos.GetTeachers();

            foreach (var teacher in teachers)
            {
                var row = dt.NewRow();

                row["ID"] = Convert.ToInt32(teacher.Id);
                row["First Name"] = teacher.Firstname;
                row["Last Name"] = teacher.Lastname;
                row["Age"] = Convert.ToInt32(teacher.Age);
                row["Gender"] = teacher.Gender;
                row["Phone"] = Convert.ToInt32(teacher.Phone);
                row["Address"] = teacher.Address;
                row["Email"] = teacher.Email;
                row["Status"] = teacher.Status;
                row["Role Code"] = teacher.RolesCode;

                dt.Rows.Add(row);
            }

            dgvTeacher.DataSource = dt;
        }

        private void TeacherList_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                (this.ClientSize.Width / 2) - (panel1.Width / 2),
                (this.ClientSize.Height / 2) - (panel1.Height / 2)
            );
        }
    }
}
