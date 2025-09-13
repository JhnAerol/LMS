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
    public partial class AddSubject : Form
    {
        public AddSubject()
        {
            InitializeComponent();
            DisplayAvTeacher();
        }

        public void DisplayAvTeacher()
        {
            var repos = new SubjectRepos();

            var display = repos.GetAvailableTeacher();
            
            foreach(var avTeacher in display)
            {
                cmbAvTeacher.Items.Add(avTeacher.FullName);
            }
        }
    }
}
