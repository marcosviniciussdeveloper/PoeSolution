using Poe.Infraestructure.Repositories;
using Poe.Modulo.Logs.Entity;

namespace Poe.Infraestructure.Repositories;

public interface IEventRepository: IRepositoryBase<LogEventEntity>
{
    Task<IEnumerable<LogEventEntity>> GetAllEventsByTimeRangeAsync(DateTime start, DateTime end);
    
}