using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CharacterPhotonAdapter : MonoBehaviour
    {
        [SerializeField]
        private CharacterCanvasView _characterCanvasView;
        
        [PunRPC]
        private void RPC_UpdateCoinWalletView(int value)
        {
            _characterCanvasView.UpdateCoinWallet(value);
        }
        
        [PunRPC]
        private void RPC_UpdateHealthBar(float maxValue, float currentValue)
        {
            _characterCanvasView.UpdateHealthBar(currentValue / maxValue);
        }
    }
}