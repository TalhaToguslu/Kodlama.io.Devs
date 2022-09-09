﻿using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Profiles
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateProgramingLanguageCommand, ProgramingLanguage>().ReverseMap();
            CreateMap<CreateProgramingLanguageCommand, ProgramingLanguageDto>().ReverseMap();
            CreateMap<ProgramingLanguage, ProgramingLanguageDto>().ReverseMap();
        }
    }
}
