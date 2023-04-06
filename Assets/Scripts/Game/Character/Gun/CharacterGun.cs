using System.Collections;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CharacterGun : MonoBehaviour
    {
        private BulletPool _bulletPool;
        private CharacterSetting _characterSetting;
        private CoroutineService _coroutineService;
        private bool _isReload = true;

        [Inject]
        private void Construct(BulletPool bulletPool, CharacterSetting characterSetting,
            CoroutineService coroutineService)
        {
            _characterSetting = characterSetting;
            _bulletPool = bulletPool;
            _coroutineService = coroutineService;
        }

        private IEnumerator WaitReload()
        {
            yield return new WaitForSeconds(_characterSetting.GunReloadTime);
            _isReload = true;
        }

        private void Shoot()
        {
            _isReload = false;
            Bullet bullet = _bulletPool.Spawn();
            bullet.Activate();
            _coroutineService.StartCoroutine(WaitReload());
        }

        public void TryShoot()
        {
            if (_isReload)
            {
                Shoot();
            }
        }
    }
}