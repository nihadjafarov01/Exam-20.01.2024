using Exam6.Core.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Exam6.Core.Models
{
    public class Instructor : BaseModel
    {
        [MaxLength(32)]
        public string Fullname { get; set; }
        [MaxLength(32)]
        public string Position { get; set; }
        public string ImageUrl { get; set; }
    }
}
