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

        public float Damage => _damage;

        public event Action<Bullet> OnDestroyed;
        
        public void SetSpawnPoint(Transform point)
        {
            transform.position = point.position;
            transform.up = point.up;
        }

        // private void OnCollisionEnter2D(Collision2D col)
        // {
        //     if (PhotonView.IsMine)
        //     {
        //         if (col.gameObject.TryGetComponent(out CharacterHealth characterHealth))
        //         {
        //             PhotonView character = characterHealth.PhotonView;
        //             character.RPC("RPC_TakeDamage", RpcTarget.AllBuffered, _damage);
        //         }
        //     
        //         OnDestroyed?.Invoke(this);
        //     }
        // }

        public void Activate() => gameObject.SetActive(true);
        
        public void Deactivate() => gameObject.SetActive(false);

        public void Destroy()
        {
            Deactivate();
            OnDestroyed?.Invoke(this);
        }

        public void Initialize(BulletSetting bulletSetting)
        {
            gameObject.GetComponent<BulletMovement>().Initialize(bulletSetting.SpeedMovement);
            _damage = bulletSetting.Damage;
            Debug.Log($"{_damage} -- {Damage}");
        }
    }
}