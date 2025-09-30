using RegistrationForm.AdminDashvoardMdiPages;
using RegistrationForm.AdminDashvoardMdiPages.Students;
using RegistrationForm.AdminDashvoardMdiPages.Teacher;
using RegistrationForm.AdminDashvoardMdiPages.Subjects;
using RegistrationForm.MdiPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm
{
    public partial class AdminDashboard : Form
    {

        AddStudent addstudent;
        Statistics statistics;
        AddTeacher addteacher;
        Subjects subjects;
        Logs logs;
        StudentList studentList;
        TeacherList teacherList;

        bool sidebarExpand = true;
        bool studentBarExpand = false;
        bool teacherBarExpand = false;

        public AdminDashboard()
        {
            InitializeComponent();
            lblName.Text = User.Name;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 5;
                if (sidebar.Width <= 61)
                {
                    sidebarExpand = false;
                    timer1.Stop();
                }
            }
            else
            {
                sidebar.Width += 5;
                if(sidebar.Width >= 214)
                {
                    sidebarExpand = true;
                    timer1.Stop();
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (!studentBarExpand)
            {
                StudentBar.Height += 5;
                if (StudentBar.Height >= 120)
                {
                    studentBarExpand = true;
                    timer2.Stop();
                }
            }
            else
            {
                StudentBar.Height -= 5;
                if (StudentBar.Height <= 43)
                {
                    studentBarExpand = false;
                    timer2.Stop();
                }
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (!teacherBarExpand)
            {
                TeacherBar.Height += 5;
                if (TeacherBar.Height >= 120)
                {
                    teacherBarExpand = true;
                    timer3.Stop();
                }
            }
            else
            {
                TeacherBar.Height -= 5;
                if (TeacherBar.Height <= 43)
                {
                    teacherBarExpand = false;
                    timer3.Stop();
                }
            }
        }
        private void btnSidebar_Click(object sender, EventArgs e)
        {
        }

        private void btnStudentBar_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }
        private void btnTeacherBar_Click(object sender, EventArgs e)
        {
            timer3.Start();
        }
        private void btnAddStudent_Click(object sender, EventArgs e)
        {

            if (addstudent == null)
            {
                addstudent = new AddStudent();
                addstudent.FormClosed += Addstudent_FormClosed;
                addstudent.MdiParent = this;
                addstudent.Dock = DockStyle.Fill;
                addstudent.Show();
                
            }
            else
            {
                addstudent.Activate();
            }
        }

        private void Addstudent_FormClosed(object sender, FormClosedEventArgs e)
        {
            addstudent = null;
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnStatistics.BackColor = Color.Gray;


            if (statistics == null)
            {
                statistics = new Statistics();
                statistics.FormClosed += Statistic_FormClosed;
                statistics.MdiParent = this;
                statistics.Dock = DockStyle.Fill;
                statistics.Show();
                btnStatistics.BackColor = Color.White;
            }
            else
            {
                btnStatistics.BackColor = Color.Gray;
                statistics.Activate();
            }
        }

        private void Statistic_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            statistics = null;
        }

        private void btnAddTeacher_Click(object sender, EventArgs e)
        {
            if(addteacher == null)
            {
                addteacher = new AddTeacher();
                addteacher.FormClosed += Addteacher_FormClosed;
                addteacher.MdiParent = this;
                addteacher.Dock = DockStyle.Fill;
                addteacher.Show();
            }
            else
            {
                addteacher.Activate();
            }
        }

        private void Addteacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            addteacher = null;
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnSubjects.BackColor = Color.Gray;

            if (subjects == null)
            {
                subjects = new Subjects();
                subjects.FormClosed += Subjects_FormClosed;
                subjects.MdiParent = this;
                subjects.Dock = DockStyle.Fill;
                subjects.Show();
            }
            else
            {
                subjects.Activate();
            }
        }

        private void Subjects_FormClosed(object sender, FormClosedEventArgs e)
        {
            subjects = null;
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btnLogs.BackColor = Color.Gray;
            if (logs == null)
            {
                logs = new Logs();
                logs.FormClosed += Logs_FormClosed;
                logs.MdiParent = this;
                logs.Dock = DockStyle.Fill;
            }
            else
            {
                logs.Activate();
            }
        }

        private void Logs_FormClosed(object sender, FormClosedEventArgs e)
        {
            logs = null;
        }

        private void btnTeacherList_Click(object sender, EventArgs e)
        {
            if (teacherList == null)
            {
                teacherList = new TeacherList();
                teacherList.FormClosed += TeacherList_FormClosed;
                teacherList.MdiParent = this;
                teacherList.Dock = DockStyle.Fill;
                teacherList.Show();
            }
            else
            {
                teacherList.Activate();
            }
        }

        private void TeacherList_FormClosed(object sender, FormClosedEventArgs e)
        {
            teacherList = null;
        }

        private void btnStudentList_Click(object sender, EventArgs e)
        {
            if (studentList == null)
            {
                studentList = new StudentList();
                studentList.FormClosed += StudentList_FormClosed;
                studentList.MdiParent = this;
                studentList.Dock = DockStyle.Fill;
                studentList.Show();
            }
            else
            {
                studentList.Activate();
            }
        }

        private void StudentList_FormClosed(object sender, FormClosedEventArgs e)
        {
            studentList = null;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to log out?", "Log out Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                new LoginForm().Show();

            }
        }

        private void AdminDashboard_Shown(object sender, EventArgs e)
        {
            if (statistics == null)
            {
                statistics = new Statistics();
                statistics.FormClosed += Statistic_FormClosed;
                statistics.MdiParent = this;
                statistics.Dock = DockStyle.Fill;
                statistics.Show();
            }
            else
            {
                statistics.Activate();
            }
        }

        private void ResetButtonColors()
        {
            btnStatistics.BackColor = Color.White;
            btnSubjects.BackColor = Color.White;
            btnLogs.BackColor = Color.White;
        }
    }
}
