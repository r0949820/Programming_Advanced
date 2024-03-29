﻿namespace ProefexamenJan.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public bool Contract { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return FullName;
        }
    }
}
