using GeneralLog.Domain.Entities;

namespace GeneralLog.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task AddLogAsync(LogEntry log);
        Task<List<LogEntry>> GetLogsByCedulaAsync(string cedula);
    }
}
