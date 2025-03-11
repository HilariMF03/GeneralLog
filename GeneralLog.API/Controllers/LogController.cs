using GeneralLog.Application.Services;
using GeneralLog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GeneralLog.API.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly LogService _logService;

        public LogController(LogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogEntry log)
        {
            await _logService.AddLogAsync(log);
            return Created("", new { message = "Log registrado exitosamente" });
        }

        [HttpGet("{cedula}")]
        public async Task<IActionResult> GetLogsByCedula(string cedula)
        {
            var logs = await _logService.GetLogsByCedulaAsync(cedula);
            return Ok(logs);
        }
    }
}
