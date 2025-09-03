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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        string ConnectionString = @"Data Source=DESKTOP-H4JIUJU\SQLEXPRESS;Initial Catalog=Proel2D;Integrated Security=True";

        int failedAttepmts = 0;
        int timer = 10;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            { 
                SqlCommand cmd = new SqlCommand("SP_Login", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("Password", txtPassword.Text);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if(string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
                    {
                        if (string.IsNullOrEmpty(txtUsername.Text) && string.IsNullOrEmpty(txtPassword.Text))
                        {
                            MessageBox.Show("Please input username and password", "Failed Attempts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                        }
                        else if (string.IsNullOrEmpty(txtUsername.Text))
                        {
                            MessageBox.Show("Please input username", "Failed Attempts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsername.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Please input password", "Failed Attempts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtPassword.Focus();
                        }
                    }
                    else
                    {
                        if (reader.Read())
                        {
                            string message = reader["Message"].ToString();
                            
                            MessageBox.Show(message, "Login Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if(message == "Login Successful")
                            {
                                string role = reader["RoleCode"].ToString();

                                if (role == "AD")
                                {
                                    this.Hide();
                                    new AdminDashboard().Show();
                                }
                                else if (role == "TH")
                                {
                                    this.Hide();
                                    new TeacherDashboard().Show();
                                }
                                else if (role == "ST")
                                {
                                    this.Hide();
                                    new StudentDashboard().Show();
                                }

                            }


                            if (message == "Incorrect Username or Password")
                            {
                                failedAttepmts++;

                                if (failedAttepmts == 3)
                                {
                                    txtUsername.ReadOnly = true;
                                    txtPassword.ReadOnly = true;

                                    timer1.Enabled = true;

                                    MessageBox.Show("You failed to attempt 3 times. Please wait.", "Failed Attempts", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer--;
            if(timer == 0)
            {
                txtUsername.ReadOnly = false;
                txtPassword.ReadOnly = false;

                timer1.Enabled = false;

                MessageBox.Show("Please procced.");
                failedAttepmts = 0;
                timer = 10;
            }
            
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterForm().Show();
        }
    }
}
