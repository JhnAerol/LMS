using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages
{
    public partial class Subjects : Form
    {
        public Subjects()
        {
            InitializeComponent();
        }

        private void Subjects_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
               (this.ClientSize.Width / 2) - (panel1.Width / 2),
               (this.ClientSize.Height / 2) - (panel1.Height / 2)
           );
        }
    }
}
