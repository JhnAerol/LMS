using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.AdminDashvoardMdiPages.Subjects
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public double Credits { get; set; }
        public int TeacherID { get; set; }
        public int DepartmentID { get; set; }

    }
}
