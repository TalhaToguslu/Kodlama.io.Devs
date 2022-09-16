using Application.Features.ProgramingLanguages.Dtos;
using Core.Application.Requests;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgramingLanguages.Models
{
    public class ProgramingLanguageListModel:BasePageableModel
    {
        public List<ProgramingLanguageDto> Items { get; set; }
    }
}
