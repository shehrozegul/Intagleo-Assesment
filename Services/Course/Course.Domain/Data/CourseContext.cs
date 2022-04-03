using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.DomainObject.Data
{
    public class CourseContext :DbContext
    {
        public CourseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Course>? Courses { get; set; }
        public DbSet<Models.Enrollment>? Enrollments { get; set; }
    }
}
