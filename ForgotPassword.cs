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
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        string connectionString = ConnectionString.conn;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn  = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_ForgotPassword", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string hash = PasswordEncryption.SHA256Hash(txtNewPassword.Text);

                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("Password", hash);

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

                    txtEmail.Clear();
                    txtNewPassword.Clear();
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new LoginForm().Show();
            this.Hide();
        }
    }
}
