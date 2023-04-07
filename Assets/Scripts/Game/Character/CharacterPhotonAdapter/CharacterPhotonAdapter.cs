using System;
using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CharacterPhotonAdapter : MonoBehaviour
    {
        [SerializeField]
        private CharacterCanvasView _characterCanvasView;

        public event Action<float> OnTakeDamage;
        
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
        
        [PunRPC]
        private void RPC_TakeDamage(float damage)
        {
            Debug.Log(gameObject.name);
            OnTakeDamage?.Invoke(damage);
        }
    }
}