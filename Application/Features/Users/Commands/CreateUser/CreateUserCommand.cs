using Application.Features.ProgramingLanguages.Rules;
using Application.Features.Users.Rules;
using Application.Services;
using AutoMapper;
using Core.Security.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand: IRequest<UserForRegisterDto>
    {
        public UserForRegisterDto User { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserForRegisterDto>
        {
            private readonly IUserService _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public CreateUserCommandHandler(IUserService userRepository,
                IMapper mapper,
                UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public Task<UserForRegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
