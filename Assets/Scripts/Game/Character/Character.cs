using System;
using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class Character : MonoBehaviour,
        IInitializable,
        IActivable
    {
        [SerializeField]
        private CharacterColor _characterColor;

        [SerializeField]
        private CharacterName _characterName;

        [field: SerializeField] 
        public PhotonView PhotonView { get; private set; }

        [field: SerializeField]
        public CharacterMovement CharacterMovement { get; private set; }

        [field: SerializeField]
        public CharacterGun CharacterGun { get; private set; }

        [field: SerializeField]
        public CollisionDetector CollisionDetector { get; private set; }

        [field: SerializeField]
        public CharacterPhotonAdapter CharacterPhotonAdapter { get; private set; }

        public event Action OnDiedLast;

        public void Initialize()
        {
            _characterColor.Initialize();
            _characterName.Initialize();
            CharacterMovement.Initialize();
        }

        public void SetPosition(Vector2 position) => transform.position = position;

        public void Activate() => PhotonView.RPC("RPC_Activate", RpcTarget.AllBuffered);

        public void Deactivate() => PhotonView.RPC("RPC_Deactivate", RpcTarget.AllBuffered);

        public void Died() => PhotonView.RPC("RPC_Died", RpcTarget.All);

        [PunRPC]
        private void RPC_Activate() => gameObject.SetActive(true);

        [PunRPC]
        private void RPC_Deactivate() => gameObject.SetActive(false);
        
        [PunRPC]
        private void RPC_Died() => OnDiedLast?.Invoke();
    }
}