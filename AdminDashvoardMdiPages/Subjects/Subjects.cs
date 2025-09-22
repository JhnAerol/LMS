
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using RegistrationForm.AdminDashvoardMdiPages.Students.StudentData;
using RegistrationForm.AdminDashvoardMdiPages.Subjects.SubjectData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Subjects
{
    public partial class Subjects : Form
    {
        SubjectRepos repos = new SubjectRepos();
        DataTable allSubjects;
        DataTable studentsInCourse;

        public Subjects()
        {
            InitializeComponent();
            ReadSubjects();
            ReadAllSubjects();

        }

        private void Subjects_Resize(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(
               (this.ClientSize.Width / 2) - (panel1.Width / 2),
               (this.ClientSize.Height / 2) - (panel1.Height / 2)
           );
        }

        public void ReadSubjects()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Course Name");
            dt.Columns.Add("Course Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Credits");

           
            var subjects = repos.GetAllSubjects();

            foreach (var subject in subjects)
            {
                var row = dt.NewRow();

                row["ID"] = Convert.ToInt32(subject.Id);
                row["Course Name"] = subject.CourseName;
                row["Course Code"] = subject.CourseCode;
                row["Description"] = subject.Description;
                row["Credits"] = Convert.ToInt32(subject.Credits);

                dt.Rows.Add(row);
            }

            dgvSubjects.DataSource = dt;
        }

        public void ReadAllSubjects()
        {
            allSubjects = new DataTable();

            allSubjects.Columns.Add("ID");
            allSubjects.Columns.Add("Course Name");
            allSubjects.Columns.Add("Course Code");
            allSubjects.Columns.Add("Description");
            allSubjects.Columns.Add("Credits");


            var subjects = repos.GetAllSubjects();

            foreach (var subject in subjects)
            {
                var row = allSubjects.NewRow();

                row["ID"] = Convert.ToInt32(subject.Id);
                row["Course Name"] = subject.CourseName;
                row["Course Code"] = subject.CourseCode;
                row["Description"] = subject.Description;
                row["Credits"] = Convert.ToInt32(subject.Credits);

                allSubjects.Rows.Add(row);
            }
        }

        public void ReadStudentsInCourse(int r)
        {
            studentsInCourse = new DataTable();

            studentsInCourse.Columns.Add("ID");
            studentsInCourse.Columns.Add("Course Name");
            studentsInCourse.Columns.Add("Student Name");
            studentsInCourse.Columns.Add("Status");
            studentsInCourse.Columns.Add("Role Code");
            studentsInCourse.Columns.Add("Teacher Name");

            var studinsub = repos.GetSudentsFromCourse(r);

            foreach (var stud in studinsub)
            {
                var row = studentsInCourse.NewRow();

                row["ID"] = Convert.ToInt32(stud.Id);
                row["Course Name"] = stud.CourseName;
                row["Student Name"] = stud.FullNameStudent;
                row["Status"] = stud.Status;
                row["Role Code"] = stud.RoleCode;
                row["Teacher Name"] = stud.FullNameTeaacher;

                studentsInCourse.Rows.Add(row);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvSubjects.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvSubjects.Rows[r].Cells[0].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this subject ? ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                repos.DeleteSubject(id);
                MessageBox.Show("Delete Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadSubjects();
            }
            else
            {
                MessageBox.Show("Deletion Abort!", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int r = dgvSubjects.CurrentCell.RowIndex;

            int id = Convert.ToInt32(dgvSubjects.Rows[r].Cells[0].Value.ToString());
            string courseName = dgvSubjects.Rows[r].Cells[1].Value.ToString();
            string courseCode = dgvSubjects.Rows[r].Cells[2].Value.ToString();
            string description = dgvSubjects.Rows[r].Cells[3].Value.ToString();
            int credits = Convert.ToInt32(dgvSubjects.Rows[r].Cells[4].Value.ToString());

            DialogResult dr = MessageBox.Show("Are you sure you want to update this student ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                repos.UpdateSubject(id, courseName, courseCode, description, credits);
                MessageBox.Show("Update Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadSubjects();
                ReadAllSubjects();
            }
            else
            {
                MessageBox.Show("Update Abort!", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ExportDataTableToPdfListOfSubjects(DataTable dt, string filePath)
        {
            using (var writer = new PdfWriter(filePath))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4.Rotate()))
            {
                document.SetMargins(12, 12, 12, 12);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Paragraph title = new Paragraph("List of All Subject")
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

        public void ExportDataTableToPdfListOfStudentsInSubject(DataTable dt, string filePath, string courseName)
        {
            using (var writer = new PdfWriter(filePath))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4.Rotate()))
            {
                document.SetMargins(12, 12, 12, 12);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Paragraph title = new Paragraph($"List of Student In {courseName} Course")
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
                ExportDataTableToPdfListOfSubjects(allSubjects, saveFileDialog.FileName);
                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintStudents_Click(object sender, EventArgs e)
        {
            int r = dgvSubjects.CurrentCell.RowIndex;
            string courseName = dgvSubjects.Rows[r].Cells[1].Value.ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"StudentsListFor{courseName.Replace(" ", "")}Course.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataTableToPdfListOfStudentsInSubject(studentsInCourse, saveFileDialog.FileName, courseName);
                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSubjects.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvSubjects.Rows[r].Cells[0].Value);

            ReadStudentsInCourse(id);
        }
    }
}
