using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace TapTest
{
    public class CharacterSpawner
    {
        private GamePhotonService _gamePhotonService;
        private Character _character;
        
        [Inject]
        private void Construct(GamePhotonService gamePhotonService, Character character)
        {
            _gamePhotonService = gamePhotonService;
            _character = character;
            Spawn();
        }

        private void Spawn()
        {
            _character.Activate();
            _gamePhotonService.RegisterCharacter(_character);
            

            /*DefaultPool pool = PhotonNetwork.PrefabPool as DefaultPool;
            pool.ResourceCache.Add(_character.name, _character.gameObject);
            
            Character character = _spawner.Spawn<Character>(_character.name, GetRandomPosition());
            character.Initialize();
            
            OnSpawn?.Invoke(character);*/
        }

        private Vector2 GetRandomPosition() => new(Random.Range(-10, 10), Random.Range(-10, 10));
    }
}