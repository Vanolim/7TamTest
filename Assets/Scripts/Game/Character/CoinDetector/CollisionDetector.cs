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
                PhotonNetwork.Destroy(coin.gameObject);
            }
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out IDoingDamage doingDamage))
            {
                OnTakeDamage?.Invoke(doingDamage.Damage);
                PhotonNetwork.Destroy(doingDamage.Object);
            }
        }
    }
}