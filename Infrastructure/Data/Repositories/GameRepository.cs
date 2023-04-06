using Domain.Entities;
using Domain.Interfaces.Generics;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Generic;

namespace Infrastructure.Data.Repositories
{
    public class GameRepository : GenericDataDbRepository<GameEntity>, IGameDomainRepository
    {
        public GameRepository(AppDbContext contex) : base(contex)
        {
            Context = contex;
        }

        public int CreateGame(GameEntity game)
        {
            this.AddSync(game);
            return game.Id;
        }

        public void DeleteGame(int id)
        {
            var entity = this.GetGameById(id);
            if (entity != null)
            {
                this.RemoveSync(entity);
            }

        }

        public List<GameEntity> GetAllGames()
        {
            var games = this.Context.GameEntity.ToList();
            return games;
        }

        public GameEntity GetGameById(int id)
        {
            var entity = this.Context.GameEntity.Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

        public void UpdateGame(GameEntity game)
        {
            throw new NotImplementedException();
        }
    }
}
