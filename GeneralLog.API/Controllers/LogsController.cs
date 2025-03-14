using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GeneralLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logsService;

        public LogsController(ILogsService logsService)
        {
            _logsService = logsService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogsEntry log, CancellationToken cancellationToken = default)
        {
            try
            {
                await _logsService.AddLogAsync(log, cancellationToken);
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

        [HttpGet("{clientIdentification}")]
        public async Task<IActionResult> GetLogsByClientIdentification(string clientIdentification)
        {
            try
            {
                var logs = await _logsService.GetLogsByClientIdentificationAsync(clientIdentification);
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
