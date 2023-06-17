using ARAppBackend.DTOs.Games;
using Domain.Entities;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        public GetGameResponse CreateGame(CreateGameRequest request) { 
        
            GetGameResponse response = new GetGameResponse();
            GameEntity entity = new GameEntity();

            entity.GameName = request.GameName;
            entity.Model = request.Model;

            var itemId = this._gameDomainRepository.CreateGame(entity);

            response.Id = itemId;
            response.GameName = entity.GameName;
            response.Model = entity.Model;  

            return response;
        }

        public bool DeleteGameById(int id) {
            
            var entity = this._gameDomainRepository.GetGameById(id);
            if (entity == null)
            {
                return false;
            }
            this._gameDomainRepository.DeleteGame(entity.Id);
            return true;
        }

        public GetGameResponse GetGameById(int id) { 
        
            var response = new GetGameResponse();
            var entity = this._gameDomainRepository.GetGameById(id);
            if (entity == null) {
                throw new Exception("Game not found!");
            }

            response.Id = entity.Id;
            response.GameName = entity.GameName;
            response.Model = entity.Model;


            return response;

        }

        public GetGameResponse EditGameInfo(UpdateGameRequest request) {

            var response = new GetGameResponse();
            var entity = this._gameDomainRepository.GetGameById(request.Id);
            if (entity == null)
            {
                throw new Exception("Game not found!");
            }

            entity.GameName = request.GameName;
            entity.Model = request.Model;

            this._gameDomainRepository.UpdateSync(entity);

            response.Id = entity.Id;
            response.GameName = entity.GameName;
            response.Model = entity.Model;


            return response;

        }

        public List<GetGameResponse> GetAllGames() { 
        
            var responseLs = new List<GetGameResponse>();
            var entityLs = this._gameDomainRepository.GetAllGames();

            foreach (var entity in entityLs) { 

                var item = new GetGameResponse();
                item.Id = entity.Id;
                item.GameName = entity.GameName;
                item.Model = entity.Model;

                responseLs.Add(item);

            }

            return responseLs;
        }
    }
}
