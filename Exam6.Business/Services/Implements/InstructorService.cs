using AutoMapper;
using Exam6.Business.Repositories.Interfaces;
using Exam6.Business.Services.Interfaces;
using Exam6.Business.ViewModels.InstructorVMs;
using Exam6.Core.Models;

namespace Exam6.Business.Services.Implements
{
    public class InstructorService : IInstructorService
    {
        IInstructorRepository _repo {  get; }
        IMapper _mapper { get; }

        public InstructorService(IInstructorRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task CreateAsync(InstructorCreateVM vm)
        {
            var model = _mapper.Map<Instructor>(vm);
            await _repo.CreateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id);
            await _repo.DeleteAsync(model);
        }

        public async Task<IEnumerable<InstructorListItemVM>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var rdata = _mapper.Map<IEnumerable<InstructorListItemVM>>(data);
            return rdata;
        }

        public async Task UpdateAsync(int id, InstructorUpdateVM vm)
        {
            var model = await _repo.GetByIdAsync(id);
            var rmodel = _mapper.Map(vm, model);
            await _repo.UpdateAsync(rmodel);
        }

        public async Task<InstructorUpdateVM> UpdateAsync(int id)
        {
            var model = await _repo.GetByIdAsync(id);
            var vm = _mapper.Map<InstructorUpdateVM>(model);
            return vm;
        }
    }
}
