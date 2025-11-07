using System.Data.Entity;
using System.Runtime.InteropServices.JavaScript;
using Poe.Infraestructure.Data;
using Poe.Modulo.Logs.Entity;

namespace Poe.Infraestructure.Repositories;

public class EventRepository(PoeDbContext _context) : RepositoryBase<LogEventEntity>(_context), IEventRepository
{
    
    
    public async Task<IEnumerable<LogEventEntity>> GetAllEventsByTimeRangeAsync(DateTime start, DateTime end)
    {
        return await _context.LogEvents
            .Where(e => e.Timestamp >= start && e.Timestamp <= end)
            .OrderBy(e => e.Timestamp)

            .ToListAsync();

    }
}