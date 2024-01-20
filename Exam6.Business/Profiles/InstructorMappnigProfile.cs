using AutoMapper;
using Exam6.Business.Helpers;
using Exam6.Business.ViewModels.InstructorVMs;
using Exam6.Core.Models;

namespace Exam6.Business.Profiles
{
    public class InstructorMappnigProfile : Profile
    {
        public InstructorMappnigProfile(string rootPath)
        {
            CreateMap<Instructor,InstructorListItemVM>();
            CreateMap<Instructor,InstructorUpdateVM>();

            CreateMap<InstructorCreateVM, Instructor>()
                .ForMember(i => i.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = await src.ImageFile.SaveAndProvideNameAsync(rootPath);
                    }
                });
            CreateMap<InstructorUpdateVM, Instructor>()
                .ForMember(i => i.ImageUrl, opt => opt.Ignore())
                .AfterMap(async (src, dest) =>
                {
                    if (src.ImageFile != null)
                    {
                        dest.ImageUrl = await src.ImageFile.SaveAndProvideNameAsync(rootPath);
                    }
                });
        }
    }
}
