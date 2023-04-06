using Domain.Interfaces.Generics;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        private readonly IClassDomainRepository _classDomainRepository;
        private readonly IGameDomainRepository _gameDomainRepository;
        private readonly IGameMetricDomainRepository _gameMetricDomainRepository;
        private readonly IUserDomainRepository _userDomainRepository;


        public ApplicationService(IClassDomainRepository classDomainRepository, IGameDomainRepository gameDomainRepository, IGameMetricDomainRepository gameMetricDomainRepository, IUserDomainRepository userDomainRepository)
        {
            this._classDomainRepository = classDomainRepository;
            this._gameDomainRepository = gameDomainRepository;
            this._gameMetricDomainRepository = gameMetricDomainRepository;
            this._userDomainRepository = userDomainRepository;
        }
    }
}
