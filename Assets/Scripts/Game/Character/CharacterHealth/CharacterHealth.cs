using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    [RequireComponent(typeof(PhotonView))]
    public class CharacterHealth : MonoBehaviour,
        IInitializable
    {
        public PhotonView PhotonView { get; private set; }
        
        [SerializeField]
        private CharacterHealthView _characterHealthView;
        
        private CharacterSetting _characterSetting;
        private GamePhotonService _gamePhotonService;
        private float _maxValue;
        private float _currentValue;

        [Inject]
        private void Construct(GamePhotonService gamePhotonService, CharacterSetting characterSetting)
        {
            _characterSetting = characterSetting;
            _gamePhotonService = gamePhotonService;
        }

        [PunRPC]
        private void RPC_TakeDamage(float value)
        {
            if (PhotonView.IsMine)
            {
                _currentValue -= value;
                if (_currentValue <= 0)
                {
                    _gamePhotonService.LeaveRoom();
                }

                PhotonView.RPC("RPC_UpdateHealthBar", RpcTarget.AllBuffered, 
                    _maxValue, _currentValue);
            }
        }
        
        [PunRPC]
        private void RPC_UpdateHealthBar(float maxValue, float currentValue)
        {
            if(PhotonView.IsMine)
                _characterHealthView.UpdateHealthBar(currentValue / maxValue);
        }

        public void Initialize()
        {
            PhotonView = GetComponent<PhotonView>();
            _maxValue = _characterSetting.InitHealth;
            _currentValue = _maxValue;
        }
    }
}