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

        public void Activate() => SetActivePhotonEvent(true);
        public void Deactivate() => SetActivePhotonEvent(false);

        private void SetActivePhotonEvent(bool value)
        {
            if(PhotonView.IsMine)
                PhotonView.RPC("RPC_SetActivate", RpcTarget.All, value);
        }

        [PunRPC]
        private void RPC_SetActivate(bool value) => gameObject.SetActive(value);

        public void Destroy()
        {
            Deactivate();
            OnDestroyed?.Invoke(this);
        }

        public void Initialize(BulletSetting bulletSetting)
        {
            gameObject.GetComponent<BulletMovement>().Initialize(bulletSetting.SpeedMovement);
            _damage = bulletSetting.Damage;
        }
    }
}