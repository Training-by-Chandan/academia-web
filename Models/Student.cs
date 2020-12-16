using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Web.Models
{
    
    public class Student
    {
        [Key]
        public  int Id { get; set; }
        public  string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public  string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        public  string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public  string Email { get; set; }

        public  virtual  List<ParentStudent> ParentStudents { get; set; }
    }

    public class ParentStudent
    {
        [Key]
        public int Id { get; set; }
        public  int StudentId { get; set; }
        public  int ParentId { get; set; }

        [ForeignKey("StudentId")]
        public  virtual  Student Student { get; set; }
        [ForeignKey("ParentId")]
        public  virtual  Parents Parent { get; set; }
    }
}
