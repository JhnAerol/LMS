using iText.Commons.Utils;
using RegistrationForm.AdminDashvoardMdiPages.Teacher.TeacherData;
using RegistrationForm.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace RegistrationForm
{
    public partial class Statistics : Form
    {

        string connectionString = ConnectionString.conn;

        public Statistics()
        {

            InitializeComponent();
            LoadPieChartFromSP();
            LoadPieChartFromTH();
            LoadPieChartFromSub();
            LoadEnrollmentSplineChart();
            
        }
 
        private void Statistics_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(
                (this.ClientSize.Width / 2) - (panel1.Width / 2),
                (this.ClientSize.Height / 2) - (panel1.Height / 2)
            );
        }

        private void LoadPieChartFromSub()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_CountActiveAndInactiveSubject", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int activeCount = Convert.ToInt32(reader["ActiveSubjects"]);
                        int inactiveCount = Convert.ToInt32(reader["InactiveSubjects"]);

                        chart3.Series.Clear();

                        Series series = new Series();
                        series.ChartType = SeriesChartType.Pie;


                        series.Points.AddXY("Active", activeCount);
                        series.Points.AddXY("Inactive", inactiveCount);

                        series.Label = "#VALY";
                        series.LegendText = "#VALX";
                        series.BorderColor = Color.Black;
                        series.ShadowColor = Color.DarkGray;
                        series.ShadowOffset = 5;
                        series.BorderWidth = 2;
                        series.Font = new Font("Lucida Sans", 13, FontStyle.Bold);
                        series.LabelForeColor = Color.White;

                        chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
                        chart3.ChartAreas[0].Area3DStyle.Inclination = 30;
                        chart3.ChartAreas[0].Area3DStyle.Rotation = 25;

                        chart3.Legends[0].Font = new Font("Lucida Sans", 8, FontStyle.Regular);

                        chart3.Series.Add(series);

                        chart3.Titles.Clear();
                        Title chartTitle = new Title("Active and Inactive Subject", Docking.Top,
                           new Font("Lucida Sans", 12, FontStyle.Bold), Color.DarkSlateGray);
                        chart3.Titles.Add(chartTitle);
                    }

                    reader.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadPieChartFromTH()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_CountActiveAndInactiveTeaacher", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int activeCount = Convert.ToInt32(reader["ActiveTeachers"]);
                        int inactiveCount = Convert.ToInt32(reader["InactiveTeachers"]);

                        chart2.Series.Clear();

                        Series series = new Series("TeacherStatus");
                        series.ChartType = SeriesChartType.Pie;

                        series.Points.AddXY("Active", activeCount);
                        series.Points.AddXY("Inactive", inactiveCount);

                        series.Label = "#VALY";
                        series.LegendText = "#VALX";
                        series.BorderColor = Color.Black;
                        series.ShadowColor = Color.DarkGray;
                        series.ShadowOffset = 5;
                        series.BorderWidth = 2;
                        series.Font = new Font("Lucida Sans", 13, FontStyle.Bold);
                        series.LabelForeColor = Color.White;

                        chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
                        chart2.ChartAreas[0].Area3DStyle.Inclination = 30;
                        chart2.ChartAreas[0].Area3DStyle.Rotation = 25;

                        chart2.Legends[0].Font = new Font("Lucida Sans", 8, FontStyle.Regular);

                        chart2.Series.Add(series);

                        chart2.Titles.Clear();
                        Title chartTitle = new Title("Active and Inactive Teacher", Docking.Top,
                           new Font("Lucida Sans", 12, FontStyle.Bold), Color.DarkSlateGray);
                        chart2.Titles.Add(chartTitle);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadPieChartFromSP()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_CountActiveAndInactive", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int activeCount = Convert.ToInt32(reader["ActiveStudents"]);
                        int inactiveCount = Convert.ToInt32(reader["InactiveStudents"]);

                        chart1.Series.Clear();

                        Series series = new Series();
                        series.ChartType = SeriesChartType.Pie;



                        series.Points.AddXY("Active", activeCount);
                        series.Points.AddXY("Inactive", inactiveCount);

                        series.Label = "#VALY"; 
                        series.LegendText = "#VALX";
                        series.BorderColor = Color.Black;
                        series.ShadowColor = Color.DarkGray;
                        series.ShadowOffset = 5;
                        series.BorderWidth = 2;
                        series.Font = new Font("Lucida Sans", 13, FontStyle.Bold);
                        series.LabelForeColor = Color.White;
                        

                        chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                        chart1.ChartAreas[0].Area3DStyle.Inclination = 30;
                        chart1.ChartAreas[0].Area3DStyle.Rotation = 25;

                        chart1.Legends[0].Font = new Font("Lucida Sans", 8, FontStyle.Regular);

                        chart1.Series.Add(series);

                        chart1.Titles.Clear();
                        Title chartTitle = new Title("Active and Inactive Students", Docking.Top,
                           new Font("Lucida Sans", 12, FontStyle.Bold), Color.DarkSlateGray);
                        chart1.Titles.Add(chartTitle);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadEnrollmentSplineChart()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SP_StudentEnrollmentPerYear", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    chartEnrollment.Series.Clear();

                    Series series = new Series("Enrollment");
                    series.ChartType = SeriesChartType.Spline; 
                    series.BorderWidth = 3;
                    series.IsVisibleInLegend = false;

                    foreach (DataRow row in dt.Rows)
                    {
                        int year = Convert.ToInt32(row["EnrollmentYear"]);
                        int count = Convert.ToInt32(row["StudentCount"]);
                        series.Points.AddXY(year, count);
                    }

                    chartEnrollment.Series.Add(series);

                    
                    chartEnrollment.ChartAreas[0].AxisX.Title = "Year";
                    chartEnrollment.ChartAreas[0].AxisY.Title = "Number of Students";
                    chartEnrollment.Titles.Clear();
                    Title chartTitle = new Title("Student Enrollment Trend per Year", Docking.Top,
                           new Font("Lucida Sans", 12, FontStyle.Bold), Color.DarkSlateGray);
                    chartEnrollment.Titles.Add(chartTitle);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        
    }
}
