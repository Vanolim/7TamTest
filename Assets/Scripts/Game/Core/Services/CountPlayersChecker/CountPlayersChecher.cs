using Photon.Pun;
using Zenject;

namespace TapTest
{
    public class CountPlayersChecker : ITickable,
        IInitializable
    {
        private TickableService _tickableService;
        private InputAdapter _inputAdapter;
        private GameSetting _gameSetting;
        private bool _isCheck;

        [Inject]
        private void Construct(InputAdapter inputAdapter, TickableService tickableService,
            GameSetting gameSetting)
        {
            _inputAdapter = inputAdapter;
            _tickableService = tickableService;
            _gameSetting = gameSetting;
            _tickableService.Add(this);
        }

        private bool CheckActivate() 
            => PhotonNetwork.CountOfRooms >= _gameSetting.MinCountActivateGame;

        private void Activate()
        {
            _isCheck = false;
            _inputAdapter.Activate();
        }

        private void Deactivate()
        {
            _isCheck = true;
            _inputAdapter.Deactivate();
        }
        
        public void Tick(float dt)
        {
            if (CheckActivate())
            {
                _isCheck = false;
                _inputAdapter.Activate();
            }
        }

        public void Initialize()
        {
            if (CheckActivate())
                Activate();
            else
                Deactivate();
        }
    }
}