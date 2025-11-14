using System.Diagnostics;
using Poe.Infraestructure.Repositories;
using Poe.Modulo.Logs.Entity;
using Poe.Modulo.ProcessMining.DTOs;
using Poe.Modulo.ProcessMining.Interface;

namespace Poe.Modulo.ProcessMining.Services
{
    
    //Sumary:
    // Classe que implementa a interface IProcessMiningService onde serao implementados os metodos de analise de processos para 
    // intederpretacao dos dados de logs de eventos
    
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

        // Metodo que analisa o mapa de processos com base em um intervalo de tempo fornecido
        public async Task<ProcessMapDTO> AnalyzeProcessMap(DateTime start, DateTime end)
        {
            var rawLogs = await _eventRepository.GetAllEventsByTimeRangeAsync(start, end);

            var rawLogsList = rawLogs.ToList();
            
            var logsGroupedByCase = rawLogs.GroupBy(log => log.CaseId).ToList();

            // Cria todas as transicoes entre as acoes para cada caso
            var allTransitions = logsGroupedByCase.SelectMany(group => 
                group.OrderBy(log => log.Timestamp)
                    .Zip(group.OrderBy(log => log.Timestamp).Skip(1), (current, next) => new 
                    {
                        Origin = current.Action,
                        Destination = next.Action
                    })
            );

            // Agrupa as transicoes por origem e destino, contando a frequencia de cada transicao
            
            var edges = allTransitions
                .GroupBy(t => new { t.Origin , t.Destination })
                .Select(g => new ProcessEdgeDTO
                {
                    OriginTheActivy = g.Key.Origin,
                    DestinationTheActity = g.Key.Destination,
                    FrequencyTheActity = g.Count()
                })
            .ToList();
            
            // Agrupa os logs por acao para criar os nos de atividade
            
            var activies = rawLogs.GroupBy(log => log.Action)
                .Select(g => new ActivityNodeDTO
                {
                    ActivityName = g.Key, 
                    Frequency = g.Count(),
                    AverageExecutionTime = 0.0
                })
                .ToList();
            
            
            return new ProcessMapDTO
            {
                Activities = activies,
                Edge = Enumerable.Empty<BottleneckDTO>(),
                Bottleneck = Enumerable.Empty<BottleneckDTO>(),

            };
        }
    }
}


