using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class Bullet : MonoBehaviour,
        IActivable
    {
        [field: SerializeField]
        public PhotonView PhotonView { get; private set; }

        [SerializeField]
        private float _damage;
        
        public void SetPosition(Transform position)
        {
            transform.position = position.position;
            transform.up = position.up;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(_damage);
            }
            
            if (PhotonView.IsMine)
            {
                Destroy(gameObject);
            }
            else
            {
                PhotonView.RPC(" RPC_Destroy", RpcTarget.Others);
            }
        }
        
        [PunRPC]
        private void RPC_Destroy()
        {
            if (PhotonView.IsMine)
            {
                Destroy(gameObject);
            }
        }

        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}