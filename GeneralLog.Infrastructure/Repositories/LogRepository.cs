using GeneralLog.Application.Interfaces;
using GeneralLog.Domain.Entities;
using GeneralLog.Infrastructure.Database;
using MongoDB.Driver;

namespace GeneralLog.Infrastructure.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly MongoDbContext _context;

        public LogRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task AddLogAsync(LogEntry log)
        {
            await _context.Logs.InsertOneAsync(log);
        }

        public async Task<List<LogEntry>> GetLogsByIdentificacionClienteAsync(string Identificacion)
        {
            return await _context.Logs.Find(log => log.IdentificacionCliente == Identificacion).ToListAsync();
        }
    }
}
