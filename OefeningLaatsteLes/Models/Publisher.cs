﻿namespace OefeningLaatsteLes.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
