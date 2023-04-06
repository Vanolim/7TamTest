using UnityEngine;
using Zenject;

namespace TapTest
{
    public class GamePoolInstaller : MonoInstaller
    {
        [SerializeField]
        private Bullet _bulletPrefab;

        private const int _bulletPoolInitialSize = 10;

        public override void InstallBindings()
        {
            BindBulletPool();
        }

        private void BindBulletPool()
        {
            Container
                .BindMemoryPool<Bullet, BulletPool>()
                .WithInitialSize(_bulletPoolInitialSize)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_bulletPrefab)
                .UnderTransformGroup("Bullets");
        }
    }
}