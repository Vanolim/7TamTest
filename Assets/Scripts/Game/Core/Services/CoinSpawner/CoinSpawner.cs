using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CoinSpawner : IInitializable
    {
        private GameBoard _gameBoard;
        private GameSetting _gameSetting;
        private CoinWallet _coinWallet;

        [Inject]
        private void Construct(GameBoard gameBoard, GameSetting gameSetting,
            CoinWallet coinWallet)
        {
            _gameBoard = gameBoard;
            _gameSetting = gameSetting;
            _coinWallet = coinWallet;
        }

        private void Spawn()
        {
            for (int i = 0; i < _gameSetting.CountCoins; i++)
            {
                Coin coin = PhotonNetwork.Instantiate("Coin", 
                        Vector3.zero, Quaternion.identity).GetComponent<Coin>();
                
                coin.SetPosition(_gameBoard.GetRandomSpawnPoint());
                coin.OnTacken += TakeCoin;
            }
        }

        private void TakeCoin(Coin coin)
        {
            coin.OnTacken -= TakeCoin;
            _coinWallet.Add();
            PhotonNetwork.Destroy(coin.gameObject);
        }

        public void Initialize()
        {
            Spawn();
        }
    }
}