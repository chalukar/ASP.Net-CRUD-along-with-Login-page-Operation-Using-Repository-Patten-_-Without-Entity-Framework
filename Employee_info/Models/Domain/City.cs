using System.ComponentModel.DataAnnotations;

namespace Employee_info.Models.Domain
{
    public class City
    {
        
        public int Id { get; set; }
        public string CityCode { get; set; }
        public string Cityname { get; set; }
    }
}
