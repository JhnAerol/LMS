using iText.Commons.Utils;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using RegistrationForm.AdminDashvoardMdiPages.Subjects.SubjectData;
using RegistrationForm.AdminDashvoardMdiPages.Teacher.TeacherData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationForm.AdminDashvoardMdiPages.Teacher
{
    public partial class TeacherList : Form
    {
        TeacherRepos repos = new TeacherRepos();
        DataTable activeTeacher;
        DataTable studentsInTeacher;

        public TeacherList()
        {
            InitializeComponent();
            ReadTeacher();
            ReadActiveTeacher();
        }

        public void ReadTeacher()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID");
            dt.Columns.Add("Hire Date");
            dt.Columns.Add("DepartmentID");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            dt.Columns.Add("Age");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Address");
            dt.Columns.Add("Email");
            dt.Columns.Add("Status");
            dt.Columns.Add("Role Code");

            var teachers = repos.GetTeachers();

            foreach (var teacher in teachers)
            {
                var row = dt.NewRow();

                row["ID"] = Convert.ToInt32(teacher.Id);
                row["Hire Date"] = teacher.HireDate;
                row["DepartmentID"] = teacher.DepartmentID;
                row["First Name"] = teacher.Firstname;
                row["Last Name"] = teacher.Lastname;
                row["Age"] = Convert.ToInt32(teacher.Age);
                row["Gender"] = teacher.Gender;
                row["Phone"] = Convert.ToInt32(teacher.Phone);
                row["Address"] = teacher.Address;
                row["Email"] = teacher.Email;
                row["Status"] = teacher.Status;
                row["Role Code"] = teacher.RolesCode;

                dt.Rows.Add(row);
            }

            dgvTeacher.DataSource = dt;
        }

        public void ReadActiveTeacher()
        {
            activeTeacher = new DataTable();

            activeTeacher.Columns.Add("ID");
            activeTeacher.Columns.Add("Hire Date");
            activeTeacher.Columns.Add("DepartmentID");
            activeTeacher.Columns.Add("First Name");
            activeTeacher.Columns.Add("Last Name");
            activeTeacher.Columns.Add("Age");
            activeTeacher.Columns.Add("Gender");
            activeTeacher.Columns.Add("Phone");
            activeTeacher.Columns.Add("Address");
            activeTeacher.Columns.Add("Email");
            activeTeacher.Columns.Add("Status");
            activeTeacher.Columns.Add("Role Code");

            var teachers = repos.ActiveTeachers();

            foreach (var teacher in teachers)
            {
                var row = activeTeacher.NewRow();

                row["ID"] = Convert.ToInt32(teacher.Id);
                row["Hire Date"] = teacher.HireDate;
                row["DepartmentID"] = teacher.DepartmentID;
                row["First Name"] = teacher.Firstname;
                row["Last Name"] = teacher.Lastname;
                row["Age"] = Convert.ToInt32(teacher.Age);
                row["Gender"] = teacher.Gender;
                row["Phone"] = Convert.ToInt32(teacher.Phone);
                row["Address"] = teacher.Address;
                row["Email"] = teacher.Email;
                row["Status"] = teacher.Status;
                row["Role Code"] = teacher.RolesCode;

                activeTeacher.Rows.Add(row);
            }
        }

        public void ReadStudentsInTeacher(int r)
        {
            studentsInTeacher = new DataTable();

            studentsInTeacher.Columns.Add("ID");
            studentsInTeacher.Columns.Add("Course Name");
            studentsInTeacher.Columns.Add("Full Name");
            studentsInTeacher.Columns.Add("Status");
            studentsInTeacher.Columns.Add("Role Code");

            var studinsub = repos.GetSudentsFromTeacher(r);

            foreach (var stud in studinsub)
            {
                var row = studentsInTeacher.NewRow();

                row["ID"] = Convert.ToInt32(stud.Id);
                row["Course Name"] = stud.CourseName;
                row["Full Name"] = stud.FullName;
                row["Status"] = stud.Status;
                row["Role Code"] = stud.RoleCode;

                studentsInTeacher.Rows.Add(row);
            }
        }

        private void TeacherList_Resize(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point(
                (this.ClientSize.Width / 2) - (panel1.Width / 2),
                (this.ClientSize.Height / 2) - (panel1.Height / 2)
            );
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int r = dgvTeacher.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvTeacher.Rows[r].Cells[0].Value);

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this teacher ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                repos.DeleteTeacher(id);
                MessageBox.Show("Delete Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadTeacher();
                ReadActiveTeacher();
            }
            else
            {
                MessageBox.Show("Deletion Abort!", "Abort", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int r = dgvTeacher.CurrentCell.RowIndex;

            int id = Convert.ToInt32(dgvTeacher.Rows[r].Cells[0].Value.ToString());
            DateTime hiredate = Convert.ToDateTime(dgvTeacher.Rows[r].Cells[1].Value.ToString());
            int depid = Convert.ToInt32(dgvTeacher.Rows[r].Cells[2].Value.ToString());
            string firstname = dgvTeacher.Rows[r].Cells[3].Value.ToString();
            string lastname = dgvTeacher.Rows[r].Cells[4].Value.ToString();
            int age = Convert.ToInt32(dgvTeacher.Rows[r].Cells[5].Value.ToString());
            string gender = dgvTeacher.Rows[r].Cells[6].Value.ToString();
            int phone = Convert.ToInt32(dgvTeacher.Rows[r].Cells[7].Value.ToString());
            string address = dgvTeacher.Rows[r].Cells[8].Value.ToString();
            string email = dgvTeacher.Rows[r].Cells[9].Value.ToString();
            string status = dgvTeacher.Rows[r].Cells[10].Value.ToString();
            string rcn = dgvTeacher.Rows[r].Cells[11].Value.ToString();

            DialogResult dr = MessageBox.Show("Are you sure you want to update this student ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                repos.UpdateTeacher(id, hiredate, depid, firstname, lastname, age, gender, phone, address, email, status, rcn);
                MessageBox.Show("Update Completed", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReadTeacher();
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

                // Title
                Paragraph title = new Paragraph("List of Active Teachers")
                    .SetFont(boldFont)
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER);
                document.Add(title);
                document.Add(new Paragraph("\n"));

                // Column widths
                float[] widths = new float[dt.Columns.Count];
                for (int i = 0; i < widths.Length; i++) widths[i] = 1f;

                Table table = new Table(UnitValue.CreatePercentArray(widths)).UseAllAvailableWidth();

                // Headers
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

                // Rows
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

        public void ExportDataTableToPdfListOfStudentsInTeacher(DataTable dt, string filePath, string teacherName, string prefix)
        {
            using (var writer = new PdfWriter(filePath))
            using (var pdf = new PdfDocument(writer))
            using (var document = new Document(pdf, PageSize.A4.Rotate()))
            {
                document.SetMargins(12, 12, 12, 12);

                PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
                PdfFont regularFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

                Paragraph title = new Paragraph($"List of Student For {prefix}{teacherName}")
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
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files (*.pdf)|*.pdf";
            sfd.FileName = "TeachersList.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportDataTableToPdf(activeTeacher, sfd.FileName);
                MessageBox.Show("Teacher list exported successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintStudents_Click(object sender, EventArgs e)
        {
            int r = dgvTeacher.CurrentCell.RowIndex;
            string firstname = dgvTeacher.Rows[r].Cells[3].Value.ToString();
            string lastname = dgvTeacher.Rows[r].Cells[4].Value.ToString();
            string gender = dgvTeacher.Rows[r].Cells[6].Value.ToString();
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
                FileName = $"StudentsListFor{fullname.Replace(" ", "")}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportDataTableToPdfListOfStudentsInTeacher(studentsInTeacher, saveFileDialog.FileName, fullname, prefix);
                MessageBox.Show("PDF exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvTeacher.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvTeacher.Rows[r].Cells[0].Value);

            ReadStudentsInTeacher(id);
        }
    }
}
