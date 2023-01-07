using Employee_info.Models.Domain;

namespace Employee_info.Repositiries
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetCity();
    }
}
