namespace Employee_info.Models.DTO
{
    public class AddRegister
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
    }
}
