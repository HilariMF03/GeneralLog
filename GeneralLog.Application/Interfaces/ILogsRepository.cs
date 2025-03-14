using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogsRepository
    {
        Task AddLogAsync(LogsEntry log);
        Task<List<LogsEntry>> GetLogsByIdentificacionClienteAsync(string identificacion);
    }
}
