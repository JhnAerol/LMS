
using RegistrationForm.AdminDashvoardMdiPages.Students.StudentData;
using RegistrationForm.AdminDashvoardMdiPages.Subjects.SubjectData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Subjects
{
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
            ReadSubjects();
        }

        private void Subjects_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
               (this.ClientSize.Width / 2) - (panel1.Width / 2),
               (this.ClientSize.Height / 2) - (panel1.Height / 2)
           );
        }

        public void ReadSubjects()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Course Name");
            dt.Columns.Add("Course Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Credits");

            var repos = new SubjectRepos();
            var subjects = repos.GetAllSubjects();

            foreach (var subject in subjects)
            {
                var row = dt.NewRow();

                row["ID"] = Convert.ToInt32(subject.Id);
                row["Course Name"] = subject.CourseName;
                row["Course Code"] = subject.CourseCode;
                row["Description"] = subject.Description;
                row["Credits"] = Convert.ToInt32(subject.Credits);

                dt.Rows.Add(row);
            }

            dgvSubjects.DataSource = dt;
        }
    }
}
