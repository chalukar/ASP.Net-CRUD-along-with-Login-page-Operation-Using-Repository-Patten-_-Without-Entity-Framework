using Dapper;
using Employee_info.DataAccess;
using Employee_info.Models.Domain;
using Employee_info.Models.DTO;
using Microsoft.AspNetCore.Mvc;
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
            var query = @"select e.Id,e.UserName,e.CityId,e.Age,e.Sex,e.JoinedDate,e.ContactNo from employee e";
                //@"select e.Id,e.UserName,c.CityName,e.Age,e.Sex,e.JoinedDate,e.ContactNo from employee e inner join city c on c.Id = e.CityId";

            using (var connection = _context.CreateConnection())
            {
                var list = await connection.QueryAsync<Employee>(query, new { });
                return list.ToList();
            }
        }
       

       
        public async Task AddEmployee(Employee employee)
        {
            var query = "INSERT INTO [Employee](Id, UserName, CityId,Age,Sex,JoinedDate,ContactNo) " +
                "VALUES (@Id, @UserName, @CityId,@Age,@Sex,@JoinedDate,@ContactNo)";

            var parameters = new DynamicParameters();
            parameters.Add("Id", employee.Id, DbType.String);
            parameters.Add("UserName", employee.UserName, DbType.String);
            parameters.Add("CityId", employee.CityId, DbType.Int32);
            parameters.Add("Age", employee.Age, DbType.String);
            parameters.Add("Sex", employee.Sex, DbType.String);
            parameters.Add("JoinedDate", employee.JoinedDate, DbType.DateTime);
            parameters.Add("ContactNo", employee.ContactNo, DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);

            }
        }

        //public async Task<Employee> GetEmployeeID()
        //{
        //    var query = @"SELECT TOP * Id FROM [dbo].[Employee] ORDER BY Id DESC ";

        //    using (var connection = _context.CreateConnection())
        //    {
        //        var list = await connection.QueryAsync<Employee>(query, new { });
        //        return list.FirstOrDefault();
        //    }
        //}

        public async Task<IEnumerable<Employee>> GetEmployeeID()
        {
            var query = @"SELECT TOP 1 * FROM [dbo].[Employee] ORDER BY Id DESC ";

            using (var connection = _context.CreateConnection())
            {
                var list = await connection.QueryAsync<Employee>(query, new { });
                return list.ToList();
            }
        }
    }
}
