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

        public void UpdateStudent(int id, DateTime enrollmentDate, string firstname, string lastname, int age, string gender, int phone, string address, string email, string status, string rcn)
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
                    cmd.Parameters.AddWithValue("RoleCodeNumber", rcn);
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
