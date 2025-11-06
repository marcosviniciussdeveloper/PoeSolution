using System.Diagnostics;

namespace Poe.Modulo.ProcessMining.DTOs;

public class ProcessMapDTO
{
    
    public IEnumerable<ActivityNodeDTO> Activities { get; set; }
    
    public IEnumerable<ProcessEdgeDTO> Edge { get; set; }
    
    public IEnumerable<BottleneckDTO> Bottleneck { get; set; }
    
  
}