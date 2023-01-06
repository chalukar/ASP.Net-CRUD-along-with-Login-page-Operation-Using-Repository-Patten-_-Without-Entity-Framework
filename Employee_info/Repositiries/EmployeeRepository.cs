using Dapper;
using Employee_info.DataAccess;
using Employee_info.Models.Domain;
using Employee_info.Models.DTO;
using System.Data;

namespace Employee_info.Repositiries
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DapperContext _context;

        public EmployeeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmplyee()
        {
            var query = @"SELECT * FROM Employee";

            using (var connection = _context.CreateConnection())
            {
                var list = await connection.QueryAsync<Employee>(query, new { });
                return list.ToList();
            }
        }

        public async Task RegisterUser(Employee employee)
        {
            var query = "INSERT INTO [Employee](Id, UserId, CityId,Age,Sex,JoinedDate,ContactNo) " +
                "VALUES (@Id, @UserId, @CityId,@Age,@Sex,@JoinedDate,@ContactNo)";

            var parameters = new DynamicParameters();
            parameters.Add("Id", employee.Id, DbType.String);
            parameters.Add("UserName", employee.UserId, DbType.Int32);
            parameters.Add("City", employee.CityId, DbType.Int32);
            parameters.Add("Sex", employee.Sex, DbType.String);
            parameters.Add("JoinedDate", employee.JoinedDate, DbType.DateTime);
            parameters.Add("ContactNo", employee.ContactNo, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }
    }
}
