using Employee_info.Models.Domain;


namespace Employee_info.Repositiries
{
    public interface IUserRepository
    {
        Task RegisterUser(User user);

       Task<User> GetUser(string UserName);
 
    }
}
