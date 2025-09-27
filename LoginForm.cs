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
    public partial class LoginForm : Form
    {
        AdminDashboard admin;
        Statistics statistics;
        public LoginForm()
        {
            InitializeComponent();
            admin = new AdminDashboard();
        }

        string Connectionstring = ConnectionString.conn;

        int failedAttepmts = 0;
        int timer = 10;

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Connectionstring))
            { 
                SqlCommand cmd = new SqlCommand("SP_Login", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                string hash = PasswordEncryption.SHA256Hash(txtPassword.Text);

                cmd.Parameters.AddWithValue("Username", txtUsername.Text);
                cmd.Parameters.AddWithValue("Password", hash);

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
                            //var schema = reader.GetSchemaTable();
                            //foreach (DataRow row in schema.Rows)
                            //{
                            //    MessageBox.Show($"{row["ColumnName"]} - {row["DataType"]}");
                            //}

                            string message = reader["Message"].ToString();
                            
                            
                            
                            MessageBox.Show(message, "Login Result", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            if (message == "Login Successful")
                            {
                                string role = reader["RoleCode"].ToString();
                                User.Name = reader["FullName"].ToString();
                                admin = new AdminDashboard();
                                

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

                                    MessageBox.Show("You failed to attempt 3 times. Please wait.", "Failed Attempts",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        reader.Close();
                    }
                    
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
            new ForgotPassword().Show();
        }
    }
}
