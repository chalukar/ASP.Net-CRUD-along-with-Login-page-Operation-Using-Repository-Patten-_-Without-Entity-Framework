using Employee_info.DataAccess;
using Employee_info.Models.Domain;

namespace Employee_info.Repositiries
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext context;

        public UserRepository(DapperContext context)
        {
            this.context = context;
        }
        public Task Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
