using UnityEngine;

namespace TapTest
{
    public interface IDoingDamage
    {
        public float Damage { get; }
        public void Destroy();
    }
}