using Employee_info.Models.Domain;

namespace Employee_info.Repositiries
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmplyee();

        Task<IEnumerable<Employee>> GetEmployeeID();
        //Task<Employee> GetEmployeeID();

        Task AddEmployee(Employee employee);
    }
}
