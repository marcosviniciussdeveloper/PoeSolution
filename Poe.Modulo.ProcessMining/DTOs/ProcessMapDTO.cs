using System.Diagnostics;
using Poe.Modulo.Logs.Entity;

namespace Poe.Modulo.ProcessMining.DTOs;

public class ProcessMapDTO
{
    
    public List<ActivityNodeDTO> Activities { get; set; }
    
    public IEnumerable<BottleneckDTO> Edge { get; set; }
    
    public IEnumerable<BottleneckDTO> Bottleneck { get; set; }
    
  
}