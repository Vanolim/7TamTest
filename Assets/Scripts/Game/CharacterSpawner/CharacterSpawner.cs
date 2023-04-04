using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CharacterSpawner : IInitializable
    {
        private Spawner _spawner;
        private Character _character;

        [Inject]
        private void Construct(Spawner spawner, Character character)
        {
            _spawner = spawner;
            _character = character;
        }

        private void Spawn()
        {
            DefaultPool pool = PhotonNetwork.PrefabPool as DefaultPool;
            pool.ResourceCache.Add(_character.name, _character.gameObject);
            
            Character character = _spawner.Spawn<Character>(_character.name, GetRandomPosition());
        }

        private Vector2 GetRandomPosition() => new(Random.Range(-10, 10), Random.Range(-10, 10));

        public void Initialize()
        {
            Spawn();
        }
    }
}