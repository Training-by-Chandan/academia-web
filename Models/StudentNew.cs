using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Academia.Web.Models
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class StudentNew : BaseModel
    {
        
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }
    }


    public class StudentClass : BaseModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Class { get; set; }
        public string EnrollYear { get; set; }
        public bool IsActive { get; set; }
    }
}
