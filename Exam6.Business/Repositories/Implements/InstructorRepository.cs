using Exam6.Business.Repositories.Interfaces;
using Exam6.Core.Models;
using Exam6.DAL.Contexts;

namespace Exam6.Business.Repositories.Implements
{
    public class InstructorRepository : GenericRepository<Instructor>, IInstructorRepository
    {
        public InstructorRepository(Exam6DbContext context) : base(context)
        {
        }
    }
}
