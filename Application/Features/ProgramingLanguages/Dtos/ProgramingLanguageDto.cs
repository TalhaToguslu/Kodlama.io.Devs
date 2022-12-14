using Application.Features.ProgramingLanguageTechnologies.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Dtos
{
    public class ProgramingLanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProgramingLanguageTechnologyIncludeDto> Technologies { get; set; }
    }
}
