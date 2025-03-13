using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogService
    {
        Task AddLogAsyc(LogEntry log);
        Task<List<LogEntry>> GetLogsByIdentificacionClienteAsync(string Identificacion);

    }
}
