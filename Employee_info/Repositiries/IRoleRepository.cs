using Employee_info.Models.Domain;

namespace Employee_info.Repositiries
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetRoles();
        
    }
}
