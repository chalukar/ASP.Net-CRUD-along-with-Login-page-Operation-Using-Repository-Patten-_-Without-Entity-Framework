namespace Employee_info.Models.DTO
{
    public class AddEmployeeDTO
    {
        public string Id { get; set; }
        public int UserId { get; set; }

        public int CityId { get; set; }

        public string Age { get; set; }
        public char Sex { get; set; }

        public DateTime JoinedDate { get; set; }
        public string ContactNo { get; set; }
    }
}
