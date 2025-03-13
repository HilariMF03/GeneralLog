using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogService
    {
        Task AddLogAsyc(LogEntry log);
        Task<List<LogEntry>> GetLogsByCedulaAsyc(string cedula);

    }
}
