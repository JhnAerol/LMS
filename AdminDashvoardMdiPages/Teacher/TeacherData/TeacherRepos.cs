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

                        var teacher = new TeacherModel()
                        {
                            Id = reader.GetInt32(0),
                            HireDate = reader.GetDateTime(1),
                            DepartmentID = reader.GetInt32(2),
                            Firstname = reader.GetString(3),
                            Lastname = reader.GetString(4),
                            Age = reader.GetInt32(5),
                            Gender = reader.GetString(6),
                            Phone = reader.GetString(7),
                            Address = reader.GetString(8),
                            Email = reader.GetString(9),
                            Status = reader.GetString(10)
                        };

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

        public List<TeacherModel> ActiveTeachers()
        {
            var teachers = new List<TeacherModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetActiveTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();


                    while (reader.Read())
                    {
                        var teacher = new TeacherModel()
                        {
                            Id = reader.GetInt32(0),
                            HireDate = reader.GetDateTime(1),
                            DepartmentID = reader.GetInt32(2),
                            Firstname = reader.GetString(3),
                            Lastname = reader.GetString(4),
                            Age = reader.GetInt32(5),
                            Gender = reader.GetString(6),
                            Phone = reader.GetString(7),
                            Address = reader.GetString(8),
                            Email = reader.GetString(9),
                            Status = reader.GetString(10)
                        };


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

        public void DeleteTeacher(int Id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_DeleteTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("TeacherID", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public void UpdateTeacher(int id, DateTime hiredate, int departmentID, string firstname, string lastname, int age, string gender, string phone, string address, string email, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_UpdateTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("TeacherID", id);
                    cmd.Parameters.AddWithValue("HireDate", hiredate);
                    cmd.Parameters.AddWithValue("DepartmentID", departmentID);
                    cmd.Parameters.AddWithValue("FirstName", firstname);
                    cmd.Parameters.AddWithValue("LastName", lastname);
                    cmd.Parameters.AddWithValue("Age", age);
                    cmd.Parameters.AddWithValue("Gender", gender);
                    cmd.Parameters.AddWithValue("Phone", phone);
                    cmd.Parameters.AddWithValue("Address", address);
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("Status", status);
                   
                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public List<StudentsInTeacherModel> GetSudentsFromTeacher(int Id)
        {
            var studInSub = new List<StudentsInTeacherModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetStudentsFromTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("TeacherID", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentsInTeacherModel studentInTeacher = new StudentsInTeacherModel();

                        studentInTeacher.Id = reader.GetInt32(0);
                        studentInTeacher.CourseName = reader.GetString(1);
                        studentInTeacher.FullName = reader.GetString(2);
                        studentInTeacher.Status = reader.GetString(3);

                        studInSub.Add(studentInTeacher);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return studInSub;
        }
    }
}
