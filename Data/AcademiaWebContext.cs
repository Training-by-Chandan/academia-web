using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Academia.Web.Data
{
    public class AcademiaWebContext : DbContext
    {
        public AcademiaWebContext (DbContextOptions<AcademiaWebContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }
    }
}
