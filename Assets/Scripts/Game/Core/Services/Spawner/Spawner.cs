using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class Spawner : MonoBehaviourPunCallbacks
    {
        public T Spawn<T>(string name, Vector2 spawnPosition) =>
            PhotonNetwork.Instantiate(name, spawnPosition, Quaternion.identity)
                .GetComponent<T>();
    }
}