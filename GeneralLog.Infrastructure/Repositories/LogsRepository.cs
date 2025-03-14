using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
using GeneralLog.Infrastructure.Database;
using MongoDB.Driver;

namespace GeneralLog.Infrastructure.Repositories
{
    public class LogsRepository : ILogsRepository
    {
        private readonly MongoDbContext _context;

        public LogsRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(LogsEntry log, CancellationToken cancellationToken = default)
        {
            await _context.Logs.InsertOneAsync(log, cancellationToken: cancellationToken);
        }

        public async Task<List<LogsEntry>> GetLogsByClientIdentificationAsync(string clientIdentification)
        {
            return await _context.Logs.Find(log => log.ClientIdentification == clientIdentification).ToListAsync();
        }
    }
}
