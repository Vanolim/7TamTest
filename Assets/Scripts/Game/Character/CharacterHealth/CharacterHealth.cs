using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CharacterHealth : MonoBehaviour,
        IDamageable,
        IInitializable
    {
        [SerializeField]
        private PhotonView _photonView;
        
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

        public void TakeDamage(float value)
        {
            if (_photonView.IsMine)
            {
                _currentValue -= value;
                if (_currentValue <= 0)
                {
                    _gamePhotonService.LeaveRoom();
                }

                _photonView.RPC("UpdateHealthBar", RpcTarget.AllBuffered, _maxValue, 
                    _currentValue);
            }
        }
        
        [PunRPC]
        private void UpdateHealthBar(float maxValue, float currentValue) => 
            _characterHealthView.UpdateHealthBar(currentValue / maxValue);

        public void Initialize()
        {
            _maxValue = _characterSetting.InitHealth;
            _currentValue = _maxValue;
        }
    }
}