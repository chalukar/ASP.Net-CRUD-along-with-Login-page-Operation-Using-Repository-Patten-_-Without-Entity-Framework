using System.ComponentModel.DataAnnotations;

namespace Employee_info.Models.Domain
{
    public class Employee
    {
        
        public string Id { get; set; }
        public string UserName { get; set; }

        public int CityId { get; set; }

        public string Age { get; set; }
        public char Sex { get; set; }

        public DateTime JoinedDate { get; set; }
        public string ContactNo { get; set; }
    }
}
