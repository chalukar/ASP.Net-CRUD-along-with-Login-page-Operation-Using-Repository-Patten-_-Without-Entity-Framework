using System.ComponentModel.DataAnnotations;

namespace Employee_info.ViewModels
{
    public class RegisterVM
    {

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Guid RoleId { get; set; }

    }
}
