using System.ComponentModel.DataAnnotations;

namespace Employee_info.Models.DTO
{
    public class RegisterDTO
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100,ErrorMessage ="The {0} must  be at least {2} and at max {1} characters long.",MinimumLength =6)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="The Password and Contirmation password do not match")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
    }
}
