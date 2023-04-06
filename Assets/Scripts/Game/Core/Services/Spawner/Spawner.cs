using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class Spawner : MonoBehaviourPunCallbacks
    {
        private DiContainer _container;
        
        public T Spawn<T>(string name, Vector2 spawnPosition) =>
            PhotonNetwork.Instantiate(name, spawnPosition, Quaternion.identity)
                .GetComponent<T>();
    }
}