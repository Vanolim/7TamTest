using UnityEngine;

namespace TapTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterColor _characterColor;

        [field: SerializeField]
        public CharacterMovement CharacterMovement { get; private set; }

        [field: SerializeField]
        public CharacterGun CharacterGun { get; private set; }
        
        public void Initialize()
        {
            _characterColor.Initialize();
        }
    }
}