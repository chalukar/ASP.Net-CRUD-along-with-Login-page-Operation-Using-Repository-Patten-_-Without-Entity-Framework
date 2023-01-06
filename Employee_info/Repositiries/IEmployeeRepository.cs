using Employee_info.Models.Domain;

namespace Employee_info.Repositiries
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmplyee();

        Task RegisterUser(Employee employee);
    }
}
