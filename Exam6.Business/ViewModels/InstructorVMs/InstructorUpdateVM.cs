using Microsoft.AspNetCore.Http;

namespace Exam6.Business.ViewModels.InstructorVMs
{
    public class InstructorUpdateVM
    {
        public string Fullname { get; set; }
        public string Position { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool IsDeleted { get; set; }
    }
}
