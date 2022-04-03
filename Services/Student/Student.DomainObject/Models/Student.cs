using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DomainObject.Models
{
    public class Student
    {
        public Guid ID { get; set; }
        public string LastName { get; set; }=string.Empty;
        public string FirstMidName { get; set; } = string.Empty;
        public string RollNo { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
