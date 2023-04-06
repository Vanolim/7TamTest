using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CoinSpawner : IInitializable
    {
        private GameBoard _gameBoard;
        private GameSetting _gameSetting;
        private Character _character;

        [Inject]
        private void Construct(GameBoard gameBoard, GameSetting gameSetting, Character character)
        {
            _gameBoard = gameBoard;
            _gameSetting = gameSetting;
            _character = character;
        }

        private void Spawn()
        {
            for (int i = 0; i < _gameSetting.CountCoins; i++)
            {
                Coin coin = PhotonNetwork.Instantiate("Coin", 
                        Vector3.zero, Quaternion.identity).GetComponent<Coin>();
                
                coin.SetPosition(_gameBoard.GetRandomSpawnPoint());
            }
        }

        public void Initialize()
        {
            if(_character.PhotonView.IsMine)
                Spawn();
        }
    }
}