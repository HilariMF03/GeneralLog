using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GeneralLog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly ILogsService _logService;

        public LogsController(ILogsService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogsEntry log)
        {
            try
            {
                await _logService.AddLogAsync(log);
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

        [HttpGet("{identificacionCliente}")]
        public async Task<IActionResult> GetLogsByIdentificacionCliente(string identificacionCliente)
        {
            try
            {
                var logs = await _logService.GetLogsByIdentificacionClienteAsync(identificacionCliente);
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
