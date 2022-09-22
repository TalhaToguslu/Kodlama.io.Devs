using Application.Services;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDBContext>, IUserService
    {
        public UserRepository(BaseDBContext context) : base(context)
        {
        }
    }
}
