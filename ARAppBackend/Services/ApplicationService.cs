using Domain.Interfaces.Generics;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {
        private readonly IClassDomainRepository _classDomainRepository;
        private readonly IGameDomainRepository _gameDomainRepository;
        private readonly IGameMetricDomainRepository _gameMetricDomainRepository;
        private readonly IUserDomainRepository _userDomainRepository;
        private readonly IPasswordRestoreDomainRepository _passwordRestoreDomainRepository;
        private readonly IMClassUserDomainRepository _mClassUserDomainRepository;
        private readonly IConfiguration _configuration;



        public ApplicationService(IConfiguration configuration, IClassDomainRepository classDomainRepository, IGameDomainRepository gameDomainRepository, IGameMetricDomainRepository gameMetricDomainRepository, IUserDomainRepository userDomainRepository, IPasswordRestoreDomainRepository passwordRestoreDomainRepository, IMClassUserDomainRepository mClassUserDomainRepository)
        {
            this._classDomainRepository = classDomainRepository;
            this._gameDomainRepository = gameDomainRepository;
            this._gameMetricDomainRepository = gameMetricDomainRepository;
            this._userDomainRepository = userDomainRepository;
            this._passwordRestoreDomainRepository = passwordRestoreDomainRepository;
            this._mClassUserDomainRepository = mClassUserDomainRepository;
            this._configuration = configuration; 
        }


    }
}
