using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGameMetricDomainRepository : IGenericDataRepository<GameMetricEntity>
    {
        int CreateMetric(GameMetricEntity metric);
        void DeleteMetric(int id);
        void UpdateMetricInfo(GameMetricEntity metric);
        GameMetricEntity GetMetricById(int id);
        List<GameMetricEntity> GetAllMetrics();
    }
}
