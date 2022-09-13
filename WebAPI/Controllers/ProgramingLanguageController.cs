using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.DeleteProgramingLanguage;
using Application.Features.ProgramingLanguages.Commands.UpdateProgramingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
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
    }
}
