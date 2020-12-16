using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Academia.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Academia.Web.Data
{
    public class AcademiaWebContext : DbContext
    {
        public AcademiaWebContext (DbContextOptions<AcademiaWebContext> options)
            : base(options)
        {
        }

       public DbSet<Student> Students { get; set; }
       public  DbSet<Parents> Parents { get; set; }
       public  DbSet<ParentStudent> ParentStudents { get; set; }
    }

    //public class NewWebContext : DbContext
    //{
    //    public NewWebContext(DbContextOptions<NewWebContext> options): base(options)
    //    {
                
    //    }

    //    public DbSet<StudentNew> StudentNews { get; set; }

    //    public  DbSet<StudentClass> StudentClasses { get; set; }
    //}


    //public class AcademiaWebContext1 : DbContext
    //{
    //    public AcademiaWebContext1(DbContextOptions<AcademiaWebContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Student> Student { get; set; }
    //}
    //public class AcademiaWebContext2 : DbContext
    //{
    //    public AcademiaWebContext2(DbContextOptions<AcademiaWebContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Student> Student { get; set; }
    //}
    //public class AcademiaWebContext3 : DbContext
    //{
    //    public AcademiaWebContext3(DbContextOptions<AcademiaWebContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Student> Student { get; set; }
    //}
    //public class AcademiaWebContext4 : DbContext
    //{
    //    public AcademiaWebContext4(DbContextOptions<AcademiaWebContext> options)
    //        : base(options)
    //    {
    //    }

    //    public DbSet<Student> Student { get; set; }
    //}
}
