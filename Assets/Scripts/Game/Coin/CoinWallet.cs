using System;
using Photon.Pun;
using Zenject;

namespace TapTest
{
    public class CoinWallet : IDisposable
    {
        private Character _character;
        public int Value { get; private set; }

        [Inject]
        private void Construct(Character character)
        {
            _character = character;
            _character.CollisionDetector.OnTakeCoin += Add;
        }

        private void Add()
        {
            Value++;
            _character.PhotonView.RPC("RPC_UpdateCoinWalletView", RpcTarget.AllBuffered, Value);
        }

        public void Dispose()
        {
            _character.CollisionDetector.OnTakeCoin -= Add;
        }
    }
}