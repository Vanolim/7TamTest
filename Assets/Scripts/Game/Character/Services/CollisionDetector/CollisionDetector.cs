using System;
using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CollisionDetector : MonoBehaviour
    {
        [SerializeField]
        private PhotonView _photonView;
        
        public event Action OnTakeCoin;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Coin coin))
            {
                OnTakeCoin?.Invoke();
                TryDestroyObject(coin.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out IDoingDamage doingDamage))
            {
                doingDamage.TakeDamageEvent(_photonView);
                doingDamage.Destroy();
            }
        }

        private void TryDestroyObject(GameObject gameObject)
        {
            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.Destroy(gameObject);
            }
        }
    }
}