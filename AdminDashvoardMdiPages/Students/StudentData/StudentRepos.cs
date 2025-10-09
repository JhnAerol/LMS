using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

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

                        var student = new StudentModel() 
                        {
                            Id = reader.GetInt32(0),
                            EnrollmentDate = reader.GetDateTime(1),
                            Firstname = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Age = reader.GetInt32(4),
                            Gender = reader.GetString(5),
                            Phone = reader.GetString(6),
                            Address = reader.GetString(7),
                            Email = reader.GetString(8),
                            Status = reader.GetString(9)
                        };

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

        public List<StudentModel> GetActiveStudents()
        {
            var students = new List<StudentModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetActiveStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        var student = new StudentModel()
                        {
                            Id = reader.GetInt32(0),
                            EnrollmentDate = reader.GetDateTime(1),
                            Firstname = reader.GetString(2),
                            Lastname = reader.GetString(3),
                            Age = reader.GetInt32(4),
                            Gender = reader.GetString(5),
                            Phone = reader.GetString(6),
                            Address = reader.GetString(7),
                            Email = reader.GetString(8),
                            Status = reader.GetString(9)
                        };

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

        public void DeleteStudent(int Id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_DeleteStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("StudentID", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public void UpdateStudent(int id, DateTime enrollmentDate, string firstname, string lastname, int age, string gender, string phone, string address, string email, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_UpdateStudent", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("StudentID", id);
                    cmd.Parameters.AddWithValue("FirstName", firstname);
                    cmd.Parameters.AddWithValue("LastName", lastname);
                    cmd.Parameters.AddWithValue("Age", age);
                    cmd.Parameters.AddWithValue("Gender", gender);
                    cmd.Parameters.AddWithValue("Phone", phone);
                    cmd.Parameters.AddWithValue("Address", address);
                    cmd.Parameters.AddWithValue("Email", email);
                    cmd.Parameters.AddWithValue("Status", status);
                    cmd.Parameters.AddWithValue("EnrollmentDate", enrollmentDate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public List<StudentCoursesAndTeacherModel> GetCoursesAndTeacher(int id)
        {
            var CAT = new List<StudentCoursesAndTeacherModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetStudentCoursesAndTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("StudentID", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    int i = 1;

                    while (reader.Read())
                    {
                        StudentCoursesAndTeacherModel cat = new StudentCoursesAndTeacherModel();

                        cat.Id = i++;
                        cat.CourseName = reader.GetString(0);
                        cat.CourseCode = reader.GetString(1);
                        cat.FullNameTeacher = reader.GetString(2);

                        CAT.Add(cat);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return CAT;
        }
    }
}
