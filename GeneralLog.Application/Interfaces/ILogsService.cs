using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogsService
    {
        Task AddLogAsync(LogsEntry log, CancellationToken cancellationToken = default);
        Task<List<LogsEntry>> GetLogsByClientIdentificationAsync(string clientIdentification);

    }
}
