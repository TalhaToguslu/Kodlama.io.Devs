using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries;
using Core.Application.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramingLanguageController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddAsync([FromBody] CreateProgramingLanguageCommand command)
        {
            ProgramingLanguageDto programingLanguageDto = await Mediator.Send(command);
            return Ok(programingLanguageDto);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] DeleteProgramingLanguageCommand command)
        {
            ProgramingLanguageDto programingLanguageDto = await Mediator.Send(command);
            return Ok(programingLanguageDto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateProgramingLanguageCommand command)
        {
            ProgramingLanguageDto programingLanguageDto = await Mediator.Send(command);
            return Ok(programingLanguageDto);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest request)
        {
            GetListProgramingLanguageQuery getListProgramingLanguageQuery = new() { PageRequest = request };
            ProgramingLanguageListModel programingLanguageListModel = await Mediator.Send(getListProgramingLanguageQuery);
            return Ok(programingLanguageListModel);
        }

        [HttpGet("getById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgramingLanguageQuery request)
        {
            ProgramingLanguageDto programingLanguageDto  = await Mediator.Send(request);
            return Ok(programingLanguageDto);
        }
    }
}
