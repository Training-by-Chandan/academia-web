using System.ComponentModel.DataAnnotations;

public class Student
{
    public int Id {get;set;}
    
    [Required(ErrorMessage ="The name of student is required")]
    [StringLength(20, MinimumLength =5, ErrorMessage ="Maximum length should be {1}, minimum length should be {2}")]
    [Display(Name="Student Name")]
    public string Name {get;set;}
    
    [DataType(DataType.Password)]
    [Display(Name="Student Passcode")]
    [Required]
    [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,15}$", ErrorMessage = "Invalid password format")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password",ErrorMessage ="The password and confirm password does not match.")]
    public string ConfirmPassword { get; set; }

    [DataType(DataType.EmailAddress)]
    [Display(Name="Student Email Address")]
    [Required]
    public string Email { get; set; }
}