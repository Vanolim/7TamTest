using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CharacterHealth : MonoBehaviour,
        IDamageable
    {
        private CharacterHealthView _characterHealthView;

        public float Value { get; private set; }
        
        public void TakeDamage(float value)
        {
            Value -= value;
        }
    }
}