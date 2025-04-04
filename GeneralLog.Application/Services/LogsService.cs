﻿using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
using System.Text.RegularExpressions;

namespace GeneralLog.Application.Services
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository _logRepository;

        public LogsService(ILogsRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task AddLogAsync(LogsEntry log, CancellationToken cancellationToken = default)
        {
            if (!IsValidClientIdentification(log.ClientIdentification))
                throw new ArgumentException("La identificación del cliente ingresada no es válida.");

            if (!IsValidDocumentType(log.DocumentType))
                throw new ArgumentException("El tipo de documento ingresado no es válido. Debe ser 'Cedula', 'RNC' o 'Pasaporte'.");

            if (string.IsNullOrWhiteSpace(log.OperationType))
                throw new ArgumentException("El tipo de operación es requerido.");

            if (string.IsNullOrWhiteSpace(log.Description))
                throw new ArgumentException("La descripción es requerida.");

            await _logRepository.AddLogAsync(log, cancellationToken);
        }

        public async Task<List<LogsEntry>> GetLogsByClientIdentificationAsync(string clientIdentification)
        {
            if (!IsValidClientIdentification(clientIdentification))
                throw new ArgumentException("La identificación del cliente ingresada no es válida.");

            return await _logRepository.GetLogsByClientIdentificationAsync(clientIdentification);
        }

        private bool IsValidClientIdentification(string clientIdentification)
        {
            return Regex.IsMatch(clientIdentification, @"^\d{3}-\d{7}-\d{1}$") || // Cedula
                   Regex.IsMatch(clientIdentification, @"^\d{9}$") || // RNC
                   Regex.IsMatch(clientIdentification, @"^[A-Z0-9]{6,9}$"); // Pasaporte
        }

        private bool IsValidDocumentType(string documentType)
        {
            return documentType == "Cedula" || documentType == "RNC" || documentType == "Pasaporte";
        }
    }
}
