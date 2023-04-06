using Photon.Pun;
using Zenject;

namespace TapTest
{
    public class CoinWallet
    {
        private int _value;
        private PhotonView _character;

        [Inject]
        private void Construct(Character character)
        {
            _character = character.PhotonView;
        }

        public void Add()
        {
            _value++;
            _character.RPC("RPC_UpdateCoinWalletView", RpcTarget.AllBuffered, _value);
        }
    }
}