﻿using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class BulletSpawner
    {
        private Bullet _bullet;
        private GamePhotonService _gamePhotonService;
        
        [Inject]
        private void Construct(Bullet bullet, GamePhotonService gamePhotonService)
        {
            _bullet = bullet;
            _gamePhotonService = gamePhotonService;
        }

        public void Spawn(Transform spawnPosition)
        {
            Bullet bullet = GameObject.Instantiate(_bullet);
            bullet.OnDestroyed += RemoveBullet;
            _gamePhotonService.RegisterBullet(bullet);
            bullet.SetPosition(spawnPosition);
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