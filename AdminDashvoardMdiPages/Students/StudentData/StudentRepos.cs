using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Students.StudentData
{
    public class StudentRepos
    {
        string connectionString = ConnectionString.conn;

        public List<StudentModel> GetStudents()
        {
            var students = new List<StudentModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetStudents", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //var schema = reader.GetSchemaTable();
                        //foreach (DataRow row in schema.Rows)
                        //{
                        //    MessageBox.Show($"{row["ColumnName"]} - {row["DataType"]}");
                        //}

                        StudentModel student = new StudentModel();

                        student.Id = reader.GetInt32(0);
                        student.Firstname = reader.GetString(1);
                        student.Lastname = reader.GetString(2);
                        student.Age = reader.GetInt32(3);
                        student.Gender = reader.GetString(4);
                        student.Phone = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5);
                        student.Address = reader.GetString(6);
                        student.Email = reader.GetString(7);
                        student.Status = reader.GetString(8);
                        student.RolesCode = reader.GetString(9);

                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return students;
        }


    }
}
