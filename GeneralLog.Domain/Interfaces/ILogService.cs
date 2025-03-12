using GeneralLog.Domain.Entities;

namespace GeneralLog.Domain.Interfaces
{
    public interface ILogService
    {
        Task AddLogAsyc(LogEntry log);
        Task<List<LogEntry>> GetLogsByCedulaAsyc(string cedula);

    }
}
