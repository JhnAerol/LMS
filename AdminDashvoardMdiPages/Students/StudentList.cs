using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using RegistrationForm.AdminDashvoardMdiPages.Students.StudentData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Students
{
    public partial class StudentList : Form
    {
        StudentRepos repos = new StudentRepos();
        DataTable activeStudents;
        DataTable coursesAndTeacher;

        public StudentList()
        {
            InitializeComponent();
            ReadStudents();
            ReadActiveStudents();
        }

        private void StudentList_Resize(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(
                (this.ClientSize.Width / 2) - (panel1.Width / 2),
                (this.ClientSize.Height / 2) - (panel1.Height / 2)
            );
        }

        public void ReadStudents()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Enrollment Date");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");
            dt.Columns.Add("Status");
            dt.Columns.Add("Role Code");

            var students = repos.GetStudents();

            foreach ( var student in students )
            {
                var row = dt.NewRow();

                row["ID"] = Convert.ToInt32(student.Id);
                row["Enrollment Date"] = Convert.ToDateTime(student.EnrollmentDate);
                row["First Name"] = student.Firstname;
                row["Last Name"] = student.Lastname;
                row["Age"] = Convert.ToInt32(student.Age);
                row["Gender"] = student.Gender;
                row["Phone"] = Convert.ToInt32(student.Phone);
                row["Address"] = student.Address;
                row["Email"] = student.Email;
                row["Status"] = student.Status;
                row["Role Code"] = student.RolesCode;

                dt.Rows.Add(row);
            }

            dgvStudents.DataSource = dt;
        }

        public void ReadActiveStudents()
        {
            activeStudents = new DataTable();

            activeStudents.Columns.Add("ID");
            activeStudents.Columns.Add("Enrollment Date");
            activeStudents.Columns.Add("First Name");
            activeStudents.Columns.Add("Last Name");
            activeStudents.Columns.Add("Age");
            activeStudents.Columns.Add("Gender");
            activeStudents.Columns.Add("Phone");
            activeStudents.Columns.Add("Address");
            activeStudents.Columns.Add("Email");
            activeStudents.Columns.Add("Status");
            activeStudents.Columns.Add("Role Code");

            var students = repos.GetActiveStudents();

            foreach (var student in students)
            {
                var row = activeStudents.NewRow();

                row["ID"] = Convert.ToInt32(student.Id);
                row["Enrollment Date"] = Convert.ToDateTime(student.EnrollmentDate);
                row["First Name"] = student.Firstname;
                row["Last Name"] = student.Lastname;
                row["Age"] = Convert.ToInt32(student.Age);
                row["Gender"] = student.Gender;
                row["Phone"] = Convert.ToInt32(student.Phone);
                row["Address"] = student.Address;
                row["Email"] = student.Email;
                row["Status"] = student.Status;
                row["Role Code"] = student.RolesCode;

                activeStudents.Rows.Add(row);
            }
        }

        public void ReadStudentCoursesAndTeacher(int r)
        {
            coursesAndTeacher = new DataTable();

            coursesAndTeacher.Columns.Add("ID");
            coursesAndTeacher.Columns.Add("Course Name");
            coursesAndTeacher.Columns.Add("Course Code");
            coursesAndTeacher.Columns.Add("Teacher Name");

            var studinsubandteacher = repos.GetCoursesAndTeacher(r);


            foreach (var stud in studinsubandteacher)
            {
                var row = coursesAndTeacher.NewRow();

                row["ID"] = stud.Id;
                row["Course Name"] = stud.CourseName;
                row["Course Code"] = stud.CourseCode;
                row["Teacher Name"] = stud.FullNameTeacher;

                coursesAndTeacher.Rows.Add(row);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvStudents.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvStudents.Rows[r].Cells[0].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this student ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                repos.DeleteStudent(id);
                MessageBox.Show("Delete Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadStudents();
            }
            else
            {
                MessageBox.Show("Deletion Abort!", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int r = dgvStudents.CurrentCell.RowIndex;

            int id = Convert.ToInt32(dgvStudents.Rows[r].Cells[0].Value.ToString());
            DateTime enrollmentDate = Convert.ToDateTime(dgvStudents.Rows[r].Cells[1].Value.ToString());
            string firstname = dgvStudents.Rows[r].Cells[2].Value.ToString();
            string lastname = dgvStudents.Rows[r].Cells[3].Value.ToString();
            int age = Convert.ToInt32(dgvStudents.Rows[r].Cells[4].Value.ToString());
            string gender = dgvStudents.Rows[r].Cells[5].Value.ToString();
            int phone = Convert.ToInt32(dgvStudents.Rows[r].Cells[6].Value.ToString());
            string address = dgvStudents.Rows[r].Cells[7].Value.ToString();
            string email = dgvStudents.Rows[r].Cells[8].Value.ToString();
            string status = dgvStudents.Rows[r].Cells[9].Value.ToString();
            string rcn = dgvStudents.Rows[r].Cells[10].Value.ToString();

            DialogResult dr = MessageBox.Show("Are you sure you want to update this student ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                repos.UpdateStudent(id, enrollmentDate, firstname, lastname, age, gender, phone, address, email, status, rcn);
                MessageBox.Show("Update Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadStudents();
                ReadActiveStudents();
            }
            else
            {
                MessageBox.Show("Update Abort!", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExportDataTableToPdf(DataTable dt, string filePath)
        {
            using (var writer = new PdfWriter(filePath))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4.Rotate()))
            {
                document.SetMargins(12, 12, 12, 12);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Paragraph title = new Paragraph("List of Active Students")
                    .SetFont(boldFont)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);
                document.Add(new Paragraph("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < widths.Length; i++) widths[i] = 1f;

                Table table = new Table(UnitValue.CreatePercentArray(widths)).UseAllAvailableWidth();

                foreach (DataColumn col in dt.Columns)
                {
                    var header = new Paragraph(col.ColumnName)
                        .SetFont(boldFont)
                        .SetFontSize(9);
                    Cell headerCell = new Cell().Add(header)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(4);
                    table.AddHeaderCell(headerCell);
                }

                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        var p = new Paragraph(item?.ToString() ?? "")
                            .SetFont(regularFont)
                            .SetFontSize(9);

                        Cell bodyCell = new Cell().Add(p)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetPadding(4);

                        table.AddCell(bodyCell);
                    }
                }

                document.Add(table);
            }
        }

        public void ExportDataTableToPdfStudentCoursesAndTeacher(DataTable dt, string filePath, string fullname, string prefix)
        {
            using (var writer = new PdfWriter(filePath))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4.Rotate()))
            {
                document.SetMargins(12, 12, 12, 12);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Paragraph title = new Paragraph($"List of Courses and Teacher for {prefix}{fullname}")
                    .SetFont(boldFont)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);
                document.Add(new Paragraph("\n"));

                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < widths.Length; i++) widths[i] = 1f;

                Table table = new Table(UnitValue.CreatePercentArray(widths)).UseAllAvailableWidth();

                foreach (DataColumn col in dt.Columns)
                {
                    var header = new Paragraph(col.ColumnName)
                        .SetFont(boldFont)
                        .SetFontSize(9);
                    Cell headerCell = new Cell().Add(header)
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetPadding(4);
                    table.AddHeaderCell(headerCell);
                }

                foreach (DataRow row in dt.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        var p = new Paragraph(item?.ToString() ?? "")
                            .SetFont(regularFont)
                            .SetFontSize(9);

                        Cell bodyCell = new Cell().Add(p)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetPadding(4);

                        table.AddCell(bodyCell);
                    }
                }

                document.Add(table);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "StudentsList.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataTableToPdf(activeStudents, saveFileDialog.FileName);
                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintCoursesAndTeacher_Click(object sender, EventArgs e)
        {
            int r = dgvStudents.CurrentCell.RowIndex;
            string firstname = dgvStudents.Rows[r].Cells[2].Value.ToString();
            string lastname = dgvStudents.Rows[r].Cells[3].Value.ToString();
            string gender = dgvStudents.Rows[r].Cells[5].Value.ToString();
            string prefix = "";
            string fullname = $"{firstname} {lastname}";

            if (gender == "Male")
            {
                prefix = "Mr. ";
            }
            else
            {
                prefix = "Ms. ";
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"CoursesAndTeacherFor{fullname.Replace(" ", "")}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataTableToPdfStudentCoursesAndTeacher(coursesAndTeacher, saveFileDialog.FileName, fullname, prefix);
                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvStudents.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvStudents.Rows[r].Cells[0].Value);

            ReadStudentCoursesAndTeacher(id);
        }
    }
}
