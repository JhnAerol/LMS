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
                        student.EnrollmentDate = reader.GetDateTime(1);
                        student.Firstname = reader.GetString(2);
                        student.Lastname = reader.GetString(3);
                        student.Age = reader.GetInt32(4);
                        student.Gender = reader.GetString(5);
                        student.Phone = reader.IsDBNull(6) ? (int?)null : reader.GetInt32(6);
                        student.Address = reader.GetString(7);
                        student.Email = reader.GetString(8);
                        student.Status = reader.GetString(9);
                        student.RolesCode = reader.GetString(10);

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
