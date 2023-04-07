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

        // public void Activate() => gameObject.SetActive(true);
        // public void Deactivate() => gameObject.SetActive(false);

        public void Activate()
        {
            gameObject.SetActive(true);
            PhotonView.RPC("RPC_Activate", RpcTarget.OthersBuffered);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
            PhotonView.RPC("RPC_Deactivate", RpcTarget.OthersBuffered);
        }

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);
        //public void Activate() => gameObject.SetActive(true);
        
        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);
        //public void Deactivate() => gameObject.SetActive(false);
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