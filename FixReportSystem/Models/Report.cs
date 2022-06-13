namespace FixReportSystem.Models
{
    public class Report
    {
        public string ReportId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Building { get; set; }
        public string Classroom { get; set; }
        public string Furniture { get; set; }
        public string Email { get; set; }
        public string HeadCngineeringCourse { get; set; }
        public bool FurnitureOrClaim { get; set; }
        public string ReportDescription { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
