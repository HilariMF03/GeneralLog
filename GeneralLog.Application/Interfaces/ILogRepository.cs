using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogRepository
    {
        Task AddLogAsync(LogEntry log);
        Task<List<LogEntry>> GetLogsByIdentificacionClienteAsync(string identificacion);
    }
}
