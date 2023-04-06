using Domain.Entities;
using Domain.Interfaces.Generics;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories
{
    public class GameMetricRepository : GenericDataDbRepository<GameMetricEntity>, IGameMetricDomainRepository
    {
        public GameMetricRepository(AppDbContext contex) : base(contex)
        {
            Context = contex;
        }

        public int CreateMetric(GameMetricEntity metric)
        {
            this.AddSync(metric);
            return metric.Id;
        }

        public void DeleteMetric(int id)
        {
            var gameM = this.GetMetricById(id);
            if (gameM != null)
            {
                this.RemoveSync(gameM);
            }
        }

        public List<GameMetricEntity> GetAllMetrics()
        {
            var gameLs = this.Context.GameMetricEntity.ToList();
            return gameLs;
        }

        public GameMetricEntity GetMetricById(int id)
        {
            var gameM = this.Context.GameMetricEntity.Where(x => x.Id == id).FirstOrDefault();
            return gameM;
        }

        public void UpdateMetricInfo(GameMetricEntity metric)
        {
            throw new NotImplementedException();
        }
    }
}
