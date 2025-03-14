using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogsRepository
    {
        Task AddLogAsync(LogsEntry log, CancellationToken cancellationToken = default);
        Task<List<LogsEntry>> GetLogsByClientIdentificationAsync(string clientIdentification);
    }
}
