using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.DomainObject.Models
{
    public class Course
    {
        public Guid CourseID { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Credits { get; set; }

        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
