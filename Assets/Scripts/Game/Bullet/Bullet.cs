using System;
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

        public event Action<Bullet> OnDestroyed;
        
        public void SetPosition(Transform position)
        {
            transform.position = position.position;
            transform.up = position.up;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out CharacterHealth characterHealth))
            {
                PhotonView pht = characterHealth.PhotonView;
                pht.RPC("TakeDamage", RpcTarget.AllBuffered, _damage);
            }
            
            OnDestroyed?.Invoke(this);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
            PhotonView.RPC("RPC_Activate", RpcTarget.Others);
        }

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);

        public void Deactivate() => gameObject.SetActive(false);
    }
}