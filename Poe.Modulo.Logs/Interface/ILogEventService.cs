using Poe.Modulo.Logs.Entity;

namespace Poe.Modulo.Logs.Interface;

public interface ILogEventService
{
    Task RegisterEvent(LogEventEntity eventEntity );
}