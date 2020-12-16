using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Web.Models
{
    public class Parents
    {
        [Key] public int Id { get; set; }
        public GuardianType GuardianType { get; set; }
        public  string FirstName { get; set; }
        public  string MiddleName { get; set; }
        public string LastName { get; set; }
        [DataType( DataType.PhoneNumber)]
        public  string PhoneNumber { get; set; }

        public  virtual  List<ParentStudent> ParentStudents { get; set; }
    }

    public enum GuardianType
    {
        Father, 
        Mother, 
        Others
    }
}
