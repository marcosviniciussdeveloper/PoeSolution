using Microsoft.EntityFrameworkCore;
using Poe.Infraestructure.Data;
using Poe.Infraestructure.Repositories;
using Poe.Modulo.Logs.Entity;

namespace Poe.Infraestructure.Repositories;

public class EventRepository(PoeDbContext context) : RepositoryBase<LogEventEntity>(context), IEventRepository;