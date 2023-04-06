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
        private CharacterHealth _characterHealth;
        
        [field: SerializeField] 
        public PhotonView PhotonView { get; private set; }

        [field: SerializeField]
        public CharacterMovement CharacterMovement { get; private set; }

        [field: SerializeField]
        public CharacterGun CharacterGun { get; private set; }
        
        public void Initialize()
        {
            _characterColor.Initialize();
            _characterHealth.Initialize();
        }

        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}