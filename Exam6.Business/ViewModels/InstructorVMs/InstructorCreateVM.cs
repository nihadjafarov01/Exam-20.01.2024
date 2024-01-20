using Microsoft.AspNetCore.Http;

namespace Exam6.Business.ViewModels.InstructorVMs
{
    public class InstructorCreateVM
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
