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

        [field: SerializeField] 
        public PhotonView PhotonView { get; private set; }

        [field: SerializeField]
        public CharacterMovement CharacterMovement { get; private set; }

        [field: SerializeField]
        public CharacterGun CharacterGun { get; private set; }
        
        [field: SerializeField]
        public CharacterCanvasView CharacterCanvasView { get; private set; }
        
        [field: SerializeField]
        public CollisionDetector CollisionDetector { get; private set; }
        
        [field: SerializeField]
        public CharacterPhotonAdapter CharacterPhotonAdapter { get; private set; }
        
        public void Initialize()
        {
            _characterColor.Initialize();
            CharacterMovement.Initialize();
        }

        public void SetPosition(Vector2 position) => transform.position = position;

        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}