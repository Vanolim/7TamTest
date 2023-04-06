using UnityEngine;
using Zenject;

namespace TapTest
{
    public class BulletPool : MonoMemoryPool<Bullet>
    {
        protected override void OnCreated(Bullet bullet)
        {
            bullet.Deactivate();
        }
    }
}