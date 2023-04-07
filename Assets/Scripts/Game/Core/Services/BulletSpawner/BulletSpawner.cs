using System.Collections;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class BulletSpawner
    {
        private BulletSetting _bulletSetting;

        [Inject]
        private void Construct(BulletSetting bulletSetting)
        {
            _bulletSetting = bulletSetting;
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