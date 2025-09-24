using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.LogsFolder
{
    public class Log
    {
        public static void Logss(string name, string message)
        {
            string connectionString = ConnectionString.conn;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_InsertLog", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Message", message);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
