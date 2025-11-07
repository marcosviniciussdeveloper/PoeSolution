using Poe.Modulo.ProcessMining.DTOs;

namespace Poe.Modulo.ProcessMining.Interface;

public interface IProcessMiningService
{
    Task<IEnumerable<BottleneckDTO>> GetBottlenecks();
    Task<ProcessMapDTO> AnalyzeProcessMap(DateTime start , DateTime end );
}