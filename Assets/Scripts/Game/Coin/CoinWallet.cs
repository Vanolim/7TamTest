using System;
using Photon.Pun;
using Zenject;

namespace TapTest
{
    public class CoinWallet : IDisposable
    {
        private Character _character;
        private int _value;

        [Inject]
        private void Construct(Character character)
        {
            _character = character;
            _character.CollisionDetector.OnTakeCoin += Add;
        }

        private void Add()
        {
            _value++;
            _character.PhotonView.RPC("RPC_UpdateCoinWalletView", RpcTarget.AllBuffered, 
                _value);
        }

        public void Dispose()
        {
            _character.CollisionDetector.OnTakeCoin -= Add;
        }
    }
}