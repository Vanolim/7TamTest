using System;
using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(PhotonView))]
    [RequireComponent(typeof(BulletMovement))]
    public class Bullet : MonoBehaviour,
        IActivable
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

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (PhotonView.IsMine)
            {
                if (col.gameObject.TryGetComponent(out CharacterHealth characterHealth))
                {
                    PhotonView character = characterHealth.PhotonView;
                    character.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, _damage);
                }
            
                OnDestroyed?.Invoke(this);
            }
        }

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
        
        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);

        public void Initialize(BulletSetting bulletSetting)
        {
            _damage = bulletSetting.Damage;
            PhotonView = gameObject.GetComponent<PhotonView>();
            gameObject.GetComponent<BulletMovement>().Initialize(bulletSetting.SpeedMovement);
        }
    }
}