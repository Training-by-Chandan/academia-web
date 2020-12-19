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
        
        public  string PhoneNumber { get; set; }
       
        public  string Email { get; set; }

        public  virtual  List<ParentStudent> ParentStudents { get; set; }
    }

    
}
