using Application.Services;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProgramingLanguageTechnologyRepository : EfRepositoryBase<ProgramingLanguageTechnology, BaseDBContext>,
        IProgramingLanguageTechnologyRepository
    {
        public ProgramingLanguageTechnologyRepository(BaseDBContext context) : base(context)
        {
        }
    }
}
