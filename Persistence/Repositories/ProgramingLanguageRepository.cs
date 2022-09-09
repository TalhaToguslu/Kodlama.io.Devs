using Application.Services;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;


namespace Persistence.Repositories
{
    public class ProgramingLanguageRepository : EfRepositoryBase<ProgramingLanguage, BaseDBContext>,
        IProgramingLanguageRepository
    {
        public ProgramingLanguageRepository(BaseDBContext context) : base(context)
        {

        }
    }
}
