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
                        teacher.HireDate = reader.GetDateTime(1);
                        teacher.DepartmentID = reader.GetInt32(2);
                        teacher.Firstname = reader.GetString(3);
                        teacher.Lastname = reader.GetString(4);
                        teacher.Age = reader.GetInt32(5);
                        teacher.Gender = reader.GetString(6);
                        teacher.Phone = reader.GetInt32(7);
                        teacher.Address = reader.GetString(8);
                        teacher.Email = reader.GetString(9);
                        teacher.Status = reader.GetString(10);
                        teacher.RolesCode = reader.GetString(11);

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
