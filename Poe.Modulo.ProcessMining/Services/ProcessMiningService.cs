using System.Diagnostics;
using Poe.Infraestructure.Repositories;
using Poe.Modulo.ProcessMining.DTOs;
using Poe.Modulo.ProcessMining.Interface;

namespace Poe.Modulo.ProcessMining.Services
{
    public class ProcessMiningService : IProcessMiningService
    {
        private readonly IEventRepository _eventRepository;

        public ProcessMiningService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<IEnumerable<BottleneckDTO>> GetBottlenecks()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessMapDTO> AnalyzeProcessMap(DateTime start, DateTime end)
        {
            var LogsBrutos = await _eventRepository.GetAllEventsByTimeRangeAsync(start, end);


            return new ProcessMapDTO
            {
                Activities = Enumerable.Empty<ActivityNodeDTO>(),
                Edge = Enumerable.Empty<ProcessEdgeDTO>(),
                Bottleneck = Enumerable.Empty<BottleneckDTO>()

            };
        }
    }
}


