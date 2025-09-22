using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationForm.AdminDashvoardMdiPages.Subjects.SubjectData
{
    public class StudentInSubjectModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string FullNameStudent { get; set; }
        public string Status { get; set; }
        public string RoleCode { get; set; }
        public string FullNameTeaacher { get; set; }
    }
}
