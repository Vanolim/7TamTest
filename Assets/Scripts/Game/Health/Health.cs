using System;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class Health : IDisposable
    {
        private Character _character;
        private GamePhotonService _gamePhotonService;
        private float _maxValue;
        private float _currentValue;

        [Inject]
        private void Construct(Character character, CharacterSetting characterSetting,
            GamePhotonService gamePhotonService)
        {
            _maxValue = characterSetting.InitHealth;
            _currentValue = _maxValue;
            _character = character;
            _gamePhotonService = gamePhotonService;
            
            _character.CharacterPhotonAdapter.OnTakeDamage += TakeDamage;
            _character.OnDiedLast += DeadCharacter;
        }

        private void TakeDamage(float value)
        {
            _currentValue -= value;
            
            if (_currentValue <= 0)
            {
                DeadCharacter();
            }
            
            _character.PhotonView.RPC("RPC_UpdateHealthBar", RpcTarget.AllBuffered, 
                _maxValue, _currentValue);
        }

        private void DeadCharacter()
        {
            _character.Deactivate();
            _gamePhotonService.CharacterDie();
        }

        public void Dispose()
        {
            _character.CharacterPhotonAdapter.OnTakeDamage -= TakeDamage;
        }
    }
}