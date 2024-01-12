namespace OefeningPublishers.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobId { get; set; }
        public int JobLevel { get; set; }
        public int PublisherId { get; set; }
        public DateTime HireDate { get; set; }
    }
}
