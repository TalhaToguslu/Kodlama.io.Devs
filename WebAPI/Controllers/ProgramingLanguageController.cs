using Application.Features.ProgramingLanguages.Commands.CreateProgramingLanguage;
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
    }
}
