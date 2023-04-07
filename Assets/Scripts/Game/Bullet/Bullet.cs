using System;
using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(BulletMovement))]
    public class Bullet : MonoBehaviour,
        IActivable,
        IDoingDamage
    {
        [field:SerializeField]
        public PhotonView PhotonView { get; private set; }

        [SerializeField]
        private BulletMovement _bulletMovement;
        
        private float _damage;

        public event Action<Bullet> OnDestroyed;
        
        public void SetSpawnPoint(Transform point)
        {
            transform.position = point.position;
            transform.up = point.up;
        }

        public void TakeDamageEvent(PhotonView target)
        {
            if (PhotonView.IsMine)
            {
                target.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, _damage);
            }
        }

        public void Activate() => PhotonView.RPC("RPC_Activate", RpcTarget.AllBuffered);

        public void Deactivate() => PhotonView.RPC("RPC_Deactivate", RpcTarget.AllBuffered);

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);

        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);
        
        public void Destroy()
        {
            OnDestroyed?.Invoke(this);
        }

        public void Initialize(BulletSetting bulletSetting)
        {
            _bulletMovement.Initialize(bulletSetting.SpeedMovement);
            _damage = bulletSetting.Damage;
        }
    }
}