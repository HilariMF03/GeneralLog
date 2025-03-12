using GeneralLog.Domain.Entities;
using GeneralLog.Domain.Interfaces;
using System.Text.RegularExpressions;

namespace GeneralLog.Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task AddLogAsyc(LogEntry log)
        {
            if (!IsValidCedula(log.CedulaCliente))
                throw new ArgumentException("La cédula ingresada no es válida.");

            if (string.IsNullOrWhiteSpace(log.TipoOperacion))
                throw new ArgumentException("El tipo de operación es requerido.");

            if (string.IsNullOrWhiteSpace(log.Descripcion))
                throw new ArgumentException("La descripción es requerida.");

            await _logRepository.AddLogAsync(log);
        }

        public async Task<List<LogEntry>> GetLogsByCedulaAsyc(string cedula)
        {
            if (!IsValidCedula(cedula))
                throw new ArgumentException("La cédula ingresada no es válida.");

            return await _logRepository.GetLogsByCedulaAsync(cedula);
        }

        private bool IsValidCedula(string cedula)
        {
            return Regex.IsMatch(cedula, @"^\d{3}-\d{7}-\d{1}$"); //probando el formato de cedula DOM
        }
    }
}
