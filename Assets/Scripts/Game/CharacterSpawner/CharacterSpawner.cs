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
            _gamePhotonService.RegisterCharacter(_character);
            _character.Initialize();
            _character.Activate();
        }

        private Vector2 GetRandomPosition() => new(Random.Range(-10, 10), Random.Range(-10, 10));
    }
}