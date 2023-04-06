using System;
using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CollisionDetector : MonoBehaviour
    {
        public event Action OnTakeCoin;
        public event Action<float> OnTakeDamage;

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
                OnTakeDamage?.Invoke(doingDamage.Damage);
                TryDestroyObject(doingDamage.Object);
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