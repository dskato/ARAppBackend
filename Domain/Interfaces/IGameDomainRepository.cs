using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generics
{
    public interface IGameDomainRepository : IGenericDataRepository<GameEntity>
    {
        int CreateGame(GameEntity game);
        void DeleteGame(int id);
        void UpdateGame(GameEntity game);
        List<GameEntity> GetAllGames();
        GameEntity GetGameById(int id);

    }
}
