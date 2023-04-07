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
        }

        private void TakeDamage(float value)
        {
            _currentValue -= value;
            
            if (_currentValue <= 0)
            {
                _gamePhotonService.LeaveRoom();
            }
            
            _character.PhotonView.RPC("RPC_UpdateHealthBar", RpcTarget.AllBuffered, 
                _maxValue, _currentValue);
        }

        public void Dispose()
        {
            _character.CharacterPhotonAdapter.OnTakeDamage -= TakeDamage;
        }
    }
}