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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Data Source=DESKTOP-H4JIUJU\SQLEXPRESS;Initial Catalog=Proel2D;Integrated Security=True";

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn  = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ForgotPassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("Password", txtNewPassword.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string message = reader["Message"].ToString();
                        MessageBox.Show(message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
