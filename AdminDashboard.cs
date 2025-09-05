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

        AddStudent Addstud;

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
        bool sidebarExpand = true;
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

        private void btnSidebar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (Addstud == null)
            {
                Addstud = new AddStudent();
                Addstud.MdiParent = this;
                Addstud.Dock = DockStyle.Fill;
                Addstud.Show();
            }
        }
    }
}
