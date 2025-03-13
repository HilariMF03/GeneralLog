using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GeneralLog.API.Controllers
{
    [Route("api/logs")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogEntry log)
        {
            try
            {
                await _logService.AddLogAsyc(log);
                return Created("", new { message = "Log registrado exitosamente" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor.", details = ex.Message });

            }
        }

        [HttpGet("{cedula}")]
        public async Task<IActionResult> GetLogsByCedula(string cedula)
        {
            try
            {
                var logs = await _logService.GetLogsByCedulaAsyc(cedula);
                return Ok(logs);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Error interno del servidor.", details = ex.Message });
            }
        }
    }
}
