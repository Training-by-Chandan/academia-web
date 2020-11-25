using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id {get;set;}
    [Required]
    public string Name {get;set;}
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }
}