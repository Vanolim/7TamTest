using UnityEngine;

namespace TapTest
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private CharacterColor _characterColor;
        
        public void Initialize()
        {
            _characterColor.Initialize();
        }
    }
}