using System.ComponentModel.DataAnnotations;

namespace Employee_info.Models.DTO
{
    public class AddEmployeeDTO
    {
        [Required]
        [Display(Name = "Employee Code")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        public string UserName { get; set; }


        [Display(Name = "City")]
        [Required(ErrorMessage = "City is Required", AllowEmptyStrings = false)]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Age")]
        [RegularExpression(@"\d{1,3}", ErrorMessage="Please enter a valid age")]
        public string Age { get; set; }

        [Required]
        [Display(Name = "Sex")]
        public char Sex { get; set; }

        public DateTime JoinedDate { get; set; }

        [Required]
        [Display(Name = "Contact No")]
        [StringLength(10, ErrorMessage = "Contact No length can't be more than 10.")]
        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }
    }
}
