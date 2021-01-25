using System.Collections.Generic;

namespace StudyHelper.Models
{
    public class Institute
    {
        //Институт
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
    }
}