using GeneralLog.Domain.Entities;
using GeneralLog.Domain.Interfaces;

namespace GeneralLog.Application.Services
{
    public class LogService
    {
        private readonly ILogRepository _logRepository;

        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public async Task AddLogAsync(LogEntry log)
        {
            await _logRepository.AddLogAsync(log);
        }

        public async Task<List<LogEntry>> GetLogsByCedulaAsync(string cedula)
        {
            return await _logRepository.GetLogsByCedulaAsync(cedula);
        }
    }
}
