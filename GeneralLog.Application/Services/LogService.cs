using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
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
            if (!IsValidIdentificacionCliente(log.IdentificacionCliente))
                throw new ArgumentException("La identificación del cliente ingresada no es válida.");

            if (string.IsNullOrWhiteSpace(log.TipoOperacion))
                throw new ArgumentException("El tipo de operación es requerido.");

            if (string.IsNullOrWhiteSpace(log.Descripcion))
                throw new ArgumentException("La descripción es requerida.");

            await _logRepository.AddLogAsync(log);
        }

        public async Task<List<LogEntry>> GetLogsByIdentificacionClienteAsync(string identificacionCliente)
        {
            if (!IsValidIdentificacionCliente(identificacionCliente))
                throw new ArgumentException("La identificación del cliente ingresada no es válida.");

            return await _logRepository.GetLogsByIdentificacionClienteAsync(identificacionCliente);
        }

        private bool IsValidIdentificacionCliente(string identificacionCliente)
        {
            return Regex.IsMatch(identificacionCliente, @"^\d{3}-\d{7}-\d{1}$") || // Cedula
                   Regex.IsMatch(identificacionCliente, @"^\d{9}$") || // RNC
                   Regex.IsMatch(identificacionCliente, @"^[A-Z0-9]{6,9}$"); // Pasaporte
        }
    }
}
