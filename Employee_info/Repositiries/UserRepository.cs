using Dapper;
using Employee_info.DataAccess;
using Employee_info.Models.Domain;
using System.Data;

namespace Employee_info.Repositiries
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
           _context = context;
        }

        public async Task<User> GetUser(string UserName)
        {
            var query = "Select Id,UserName,Password,RoleId from [User] where UserName =@UserName";

            using (var connection = _context.CreateConnection())
            {
                var user = await connection.QuerySingleOrDefaultAsync<User>(query, new { UserName });
                return user;
            }
        }

        public async Task RegisterUser(User user)
        {
            var query = "INSERT INTO [User](UserName, Password, RoleId) " +
                "VALUES (@UserName, @Password, @RoleId)";

            var parameters = new DynamicParameters();
            parameters.Add("UserName", user.UserName, DbType.String);
            parameters.Add("Password", user.Password, DbType.String);
            parameters.Add("RoleId", user.RoleId, DbType.Int32);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
               
            }
        }

        
    }
}
