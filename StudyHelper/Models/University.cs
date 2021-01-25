using System.Collections.Generic;

namespace StudyHelper.Models
{
    public class University
    {
        //Университет
        public string Name;
        public string City;
        public List<Institute> Institutes { get; set; }
    }
}