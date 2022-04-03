using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.DomainObject.Data
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Models.Student>? Students { get; set; }
        public DbSet<Models.Enrollment>? Enrollments { get; set; }

    }
}
