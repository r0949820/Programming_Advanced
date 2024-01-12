namespace ProefexamenJan.Models
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
        public DateTime? HireDate { get; set; }

        public Job Job { get; set; }
        public Publisher Publisher { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return FullName;
        }
    }
}
