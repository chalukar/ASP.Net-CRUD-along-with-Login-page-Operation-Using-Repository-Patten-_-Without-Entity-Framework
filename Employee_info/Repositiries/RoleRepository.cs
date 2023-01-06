using Employee_info.DataAccess;
using Employee_info.Models.Domain;
using Dapper;
using System.Data;


namespace Employee_info.Repositiries
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext _context;

        public RoleRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var query = @"SELECT * FROM Role";

            using (var connection = _context.CreateConnection())
            {
                var list = await connection.QueryAsync<Role>(query, new {});
                return list.ToList();
            }
        }

       
    }
}
