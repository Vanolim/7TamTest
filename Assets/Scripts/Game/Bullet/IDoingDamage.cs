using UnityEngine;

namespace TapTest
{
    public interface IDoingDamage
    {
        public float Damage { get; }
        public GameObject Object { get; }
        public void Destroy();
    }
}