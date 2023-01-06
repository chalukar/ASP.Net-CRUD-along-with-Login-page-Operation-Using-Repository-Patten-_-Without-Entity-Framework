using Employee_info.Models.Domain;

namespace Employee_info.Repositiries
{
    public interface IUserRepository
    {
       Task Register(User user);

    }
}
