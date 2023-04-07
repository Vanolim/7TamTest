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
            => PhotonNetwork.CurrentRoom.Players.Count >= _gameSetting.MinCountActivateGame;

        private void Activate()
        {
            _isCheck = false;
            _inputAdapter.Activate();
            _tickableService.Remove(this);
        }

        private void Deactivate()
        {
            _isCheck = true;
            _inputAdapter.Deactivate();
            _tickableService.Add(this);
        }
        
        public void Tick(float dt)
        {
            if (_isCheck)
            {
                if (CheckActivate())
                {
                    _isCheck = false;
                    _inputAdapter.Activate();
                }
            }
        }

        public void Initialize()
        {
            if (CheckActivate())
            {
                _isCheck = false;
                Activate();
            }
            else
            {
                _isCheck = true;
                Deactivate();
            }
        }
    }
}