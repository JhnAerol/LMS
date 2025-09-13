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

        public List<SubjectModel> GetAvailableTeacher()
        {
            var avTeacher = new List<SubjectModel>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand("SP_GetAvTeacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        //var schema = reader.GetSchemaTable();
                        //foreach (DataRow row in schema.Rows)
                        //{
                        //    MessageBox.Show($"{row["ColumnName"]} - {row["DataType"]}");
                        //}

                        SubjectModel avTeachers = new SubjectModel();

                        avTeachers.FullName = reader.GetString(0);

                        avTeacher.Add(avTeachers);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exceptioon: " + ex.Message);
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

                    SqlCommand cmd = new SqlCommand("SP_AddCourse", connection);
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

    }
}
