using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CharacterGun : MonoBehaviour
    {
        [SerializeField]
        private Transform _shootPoint;
        
        private BulletSpawner _bulletSpawner;
        private CharacterSetting _characterSetting;
        private CoroutineService _coroutineService;
        private bool _isReload = true;

        [Inject]
        private void Construct(BulletSpawner bulletSpawner, CharacterSetting characterSetting,
            CoroutineService coroutineService)
        {
            _characterSetting = characterSetting;
            _bulletSpawner = bulletSpawner;
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
            _bulletSpawner.Spawn(_shootPoint);
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