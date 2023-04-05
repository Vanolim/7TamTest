using System.Collections;
using UnityEngine;

namespace TapTest
{
    public class CharacterGun : MonoBehaviour
    {
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
            _coroutineService.StartCoroutine(WaitReload());
        }

        public void TryShoot()
        {
            Debug.Log("Shoot");
            if (_isReload)
            {
                Shoot();
            }
        }
    }
}