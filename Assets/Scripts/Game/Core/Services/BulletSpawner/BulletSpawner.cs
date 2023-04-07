using System.Collections;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class BulletSpawner
    {
        private BulletSetting _bulletSetting;
        private CoroutineService _coroutineService;

        private const float _waitActivateBullet = 0.05f;
        
        [Inject]
        private void Construct(BulletSetting bulletSetting, CoroutineService coroutineService)
        {
            _bulletSetting = bulletSetting;
            _coroutineService = coroutineService;
        }

        public void Spawn(Transform spawnPosition)
        {
            Bullet bullet = PhotonNetwork.Instantiate("Bullet", Vector3.zero, Quaternion.identity)
                .GetComponent<Bullet>();

            InitBullet(bullet, spawnPosition);
        }

        private void InitBullet(Bullet bullet, Transform spawnPosition)
        {
            bullet.OnDestroyed += RemoveBullet;
            bullet.Initialize(_bulletSetting);
            bullet.SetSpawnPoint(spawnPosition);
            _coroutineService.StartCoroutine(WaitActivateBullet(bullet));
        }

        private IEnumerator WaitActivateBullet(Bullet bullet)
        {
            yield return new WaitForSeconds(_waitActivateBullet);
            bullet.Activate();
        }

        private void RemoveBullet(Bullet bullet)
        {
            bullet.OnDestroyed -= RemoveBullet;

            if (bullet.PhotonView.IsMine)
            {
                PhotonNetwork.Destroy(bullet.gameObject);
            }
            else
            {
                Object.Destroy(bullet.gameObject);
            }
        }
    }
}