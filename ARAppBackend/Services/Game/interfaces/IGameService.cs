using ARAppBackend.DTOs.Games;

namespace ARAppBackend
{
    public partial interface IApplicationService
    {
        GetGameResponse CreateGame(CreateGameRequest request);
        bool DeleteGameById(int id);
        GetGameResponse GetGameById(int id);
        List<GetGameResponse> GetAllGames();
        GetGameResponse EditGameInfo(UpdateGameRequest request);

    }
}
