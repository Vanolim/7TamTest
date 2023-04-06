using System.Collections;
using UnityEngine;

namespace TapTest
{
    public class CharacterGun : MonoBehaviour
    {
        [SerializeField]
        private Bullet _bullet;
        
        private CharacterSetting _characterSetting;
        private CoroutineService _coroutineService;
        private bool _isReload;

        private IEnumerator WaitReload()
        {
            yield return new WaitForSeconds(_characterSetting.GunReloadTime);
            _isReload = true;
        }

        private void Shoot()
        {
            _isReload = false;
            Instantiate(_bullet);
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