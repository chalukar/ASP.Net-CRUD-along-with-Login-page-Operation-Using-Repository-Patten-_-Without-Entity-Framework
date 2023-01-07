using Employee_info.DataAccess;
using Employee_info.Models.Domain;
using Dapper;
using System.Data;

namespace Employee_info.Repositiries
{
    public class CityRepository : ICityRepository
    {
        private readonly DapperContext _context;

        public CityRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> GetCity()
        {
            var query = @"SELECT * FROM [City]";

            using (var connection = _context.CreateConnection())
            {
                var list = await connection.QueryAsync<City>(query, new { });
                return list.ToList();
            }
        }
    }
}
