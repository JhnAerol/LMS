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

namespace RegistrationForm.AdminDashvoardMdiPages
{
    public partial class Logs : Form
    {
        DataTable dt;

        public Logs()
        {
            InitializeComponent();
            LoadLogs();
        }   

        private void Logs_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
               (this.ClientSize.Width / 2) - (panel1.Width / 2),
               (this.ClientSize.Height / 2) - (panel1.Height / 2)
           );
        }

        private void LoadLogs()
        {
            string connectionString = ConnectionString.conn;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_GetLogs", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;  // Bind logs to DataGridView
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string filterText = txtSearch.Text.Trim();
            DataView dataView = dt.DefaultView;

            if (!string.IsNullOrEmpty(filterText))
            {
                if (DateTime.TryParse(filterText, out DateTime dateFilter))
                {
                    string formattedDate = dateFilter.ToString("yyyy-MM-dd");
                    dataView.RowFilter = $"Convert([LogDate], 'System.String') LIKE '%{formattedDate}%'";
                }
                else if (TimeSpan.TryParse(filterText, out TimeSpan timeFilter))
                {
                    string formattedTime = timeFilter.ToString(@"hh\:mm");
                    dataView.RowFilter = $"Convert([LogTime], 'System.String') LIKE '%{formattedTime}%'";
                }
                else
                {
                    dataView.RowFilter = string.Format(
                        "[Name] LIKE '%{0}%' OR " +
                        "[Message] LIKE '%{0}%'",
                        filterText.Replace("'", "''")
                    );
                }
            }
            else
            {
                dataView.RowFilter = string.Empty;
            }
        }
    }
}
