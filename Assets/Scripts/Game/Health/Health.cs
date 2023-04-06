using System;
using Photon.Pun;
using Zenject;

namespace TapTest
{
    public class Health : IDisposable
    {
        private Character _character;
        private float _maxValue;
        private float _currentValue;

        [Inject]
        private void Construct(Character character, CharacterSetting characterSetting)
        {
            _maxValue = characterSetting.InitHealth;
            _currentValue = _maxValue;
            _character = character;
            _character.CollisionDetector.OnTakeDamage += TakeDamage;
        }

        private void TakeDamage(float value)
        {
            _currentValue -= value;
            if (_currentValue <= 0)
            {
                //_gamePhotonService.LeaveRoom();
            }
            
            _character.PhotonView.RPC("RPC_UpdateHealthBar", RpcTarget.AllBuffered, 
                _maxValue, _currentValue);
        }

        public void Dispose()
        {
            _character.CollisionDetector.OnTakeDamage -= TakeDamage;
        }
    }
}