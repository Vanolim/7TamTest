using System;
using Photon.Pun;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TapTest
{
    public class CharacterSpawner : IInitializable
    {
        private Spawner _spawner;
        private Character _character;

        public event Action<Character> OnSpawn;

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
            character.Initialize();
            
            OnSpawn?.Invoke(character);
        }

        private Vector2 GetRandomPosition() => new(Random.Range(-10, 10), Random.Range(-10, 10));

        public void Initialize()
        {
            Spawn();
        }
    }
}