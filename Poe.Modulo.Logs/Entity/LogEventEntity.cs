 
using Poe.Domain.Core.EntityBaseAbstractions;

namespace Poe.Modulo.Logs.Entity
{

    public class LogEventEntity : EntityBase
    {
    
        public Guid CaseId { get; set; }
        public string Action { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; }

        public string Localization  { get; set; } = string.Empty;

    }
}