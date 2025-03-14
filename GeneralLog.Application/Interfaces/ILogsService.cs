using GeneralLog.Domain.Entities;

namespace GeneralLog.Application.Interfaces
{
    public interface ILogsService
    {
        Task AddLogAsync(LogsEntry log);
        Task<List<LogsEntry>> GetLogsByClientIdentificationAsync(string clientIdentification);

    }
}
