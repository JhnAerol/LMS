using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Subjects.SubjectData
{
    public class SubjectRepos
    {
        string connectionString = ConnectionString.conn;

        public List<AvTeacherModel> GetAvailableTeacher(int departmentId)
        {
            var avTeacher = new List<AvTeacherModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetAvTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DepartmentID", departmentId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        AvTeacherModel avTeachers = new AvTeacherModel();

                        avTeachers.Name = reader.GetString(0);      
                        avTeachers.Department = reader.GetString(1); 

                        avTeacher.Add(avTeachers);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message);
            }

            return avTeacher;
        }

        public List<SubjectModel> GetAllSubjects()
        {
            var subjects = new List<SubjectModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetCourses", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        //var schema = reader.GetSchemaTable();
                        //foreach (DataRow row in schema.Rows)
                        //{
                        //    MessageBox.Show($"{row["ColumnName"]} - {row["DataType"]}");
                        //}

                        SubjectModel subject = new SubjectModel();

                        subject.Id = reader.GetInt32(0);
                        subject.CourseName = reader.GetString(1);
                        subject.CourseCode = reader.GetString(2);
                        subject.Description = reader.GetString(3);
                        subject.Credits = Convert.ToDouble(reader.GetDecimal(4));
                        subject.Status = reader.GetString(5);

                        subjects.Add(subject);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return subjects;
        }

        public List<SubjectModel> GetSubjectHandler()
        {
            var instructors = new List<SubjectModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_TeacherInCourse", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        SubjectModel instructor = new SubjectModel();

                        instructor.Id = reader.GetInt32(0);
                        instructor.FullName = reader.GetString(1);

                        instructors.Add(instructor);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return instructors;
        }

        public List<SubjectModel> GetSubjectStudent()
        {
            var subsutdents = new List<SubjectModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_StudentInCourse", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        SubjectModel substudent = new SubjectModel();

                        substudent.Id = reader.GetInt32(0);
                        substudent.FullName = reader.GetString(1);

                        subsutdents.Add(substudent);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }

            return subsutdents;
        }

        public void UpdateSubject(int id, string courseName, string courseCode, string description, int creadits, string status )
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_UpdateCourse", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("CourseID", id);
                    cmd.Parameters.AddWithValue("CourseName", courseName);
                    cmd.Parameters.AddWithValue("CourseCode", courseCode);
                    cmd.Parameters.AddWithValue("Description", description);
                    cmd.Parameters.AddWithValue("Credits", creadits);
                    cmd.Parameters.AddWithValue("Status", status);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public void AddSubject(string courseName, string courseCode, string description, int creadits, string teachername, string departmentname, string status)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_AddCourses", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("CourseName", courseName);
                    cmd.Parameters.AddWithValue("CourseCode", courseCode);
                    cmd.Parameters.AddWithValue("Description", description);
                    cmd.Parameters.AddWithValue("Credits", creadits);
                    cmd.Parameters.AddWithValue("TeacherName", teachername);
                    cmd.Parameters.AddWithValue("DepartmentName ", departmentname);
                    cmd.Parameters.AddWithValue("Status", status);

                    SqlDataReader reader = cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public void DeleteSubject(int Id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_DeleteSubject", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("CourseID", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
            }
        }

        public List<StudentInSubjectModel> GetSudentsFromCourse(int Id)
        {
            var studInSub = new List<StudentInSubjectModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetStudentFromCourse", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("CourseID", Id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        StudentInSubjectModel studentInSub = new StudentInSubjectModel();

                        studentInSub.Id = reader.GetInt32(0);
                        studentInSub.CourseName = reader.GetString(1);
                        studentInSub.FullNameStudent = reader.GetString(2);
                        studentInSub.Status = reader.GetString(3);
                        studentInSub.RoleCode = reader.GetString(4);
                        studentInSub.FullNameTeaacher = reader.GetString(5);

                        studInSub.Add(studentInSub);
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
