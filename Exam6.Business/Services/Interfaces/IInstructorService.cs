using Exam6.Business.ViewModels.InstructorVMs;
using Exam6.Core.Models;

namespace Exam6.Business.Services.Interfaces
{
    public interface IInstructorService
    {
        public Task<IEnumerable<InstructorListItemVM>> GetAllAsync();
        public Task CreateAsync(InstructorCreateVM vm);
        public Task UpdateAsync(int id, InstructorUpdateVM vm);
        public Task<InstructorUpdateVM> UpdateAsync(int id);
        public Task DeleteAsync(int id);
    }
}
