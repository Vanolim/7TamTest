using UnityEngine;
using Zenject;

namespace TapTest
{
    public class BulletSpawner
    {
        private BulletPool _bulletPool;
        private GamePhotonService _gamePhotonService;
        
        [Inject]
        private void Construct(BulletPool bulletPool, GamePhotonService gamePhotonService)
        {
            _bulletPool = bulletPool;
            _gamePhotonService = gamePhotonService;
        }

        public void Spawn(Transform spawnPosition)
        {
            Bullet bullet = _bulletPool.Spawn();
            _gamePhotonService.RegisterBullet(bullet);
            bullet.SetPosition(spawnPosition);
            bullet.Activate();
        }
    }
}