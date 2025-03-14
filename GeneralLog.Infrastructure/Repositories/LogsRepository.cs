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

        public async Task AddLogAsync(LogsEntry log)
        {
            await _context.Logs.InsertOneAsync(log);
        }

        public async Task<List<LogsEntry>> GetLogsByIdentificacionClienteAsync(string Identificacion)
        {
            return await _context.Logs.Find(log => log.IdentificacionCliente == Identificacion).ToListAsync();
        }
    }
}
