using RegistrationForm.AdminDashvoardMdiPages.Students.StudentData;
using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Teacher.TeacherData
{
    public class TeacherRepos
    {
        string connectionString = ConnectionString.conn;

        public List<TeacherModel> GetTeachers()
        {
            var teachers = new List<TeacherModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetTeachers", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //var schema = reader.GetSchemaTable();
                        //foreach (System.Data.DataRow row in schema.Rows)
                        //{
                        //    MessageBox.Show($"{row["ColumnName"]} - {row["DataType"]}");
                        //}

                        TeacherModel teacher = new TeacherModel();

                        teacher.Id = reader.GetInt32(0);
                        teacher.Firstname = reader.GetString(1);
                        teacher.Lastname = reader.GetString(2);
                        teacher.Age = reader.GetInt32(3);
                        teacher.Gender = reader.GetString(4);
                        teacher.Phone = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5);
                        teacher.Address = reader.GetString(6);
                        teacher.Email = reader.GetString(7);
                        teacher.Status = reader.GetString(8);
                        teacher.RolesCode = reader.GetString(9);

                        teachers.Add(teacher);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return teachers;
        }


    }
}
