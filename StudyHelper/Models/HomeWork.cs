using System.Web;

namespace StudyHelper.Models
{
    public class HomeWork
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string WorkName { get; set; }
        public int VariantNumber { get; set; }
        public HttpPostedFileBase PostedFile { get; set; }
    }
}