using Zenject;

namespace TapTest
{
    public class CharacterSpawner
    {
        private GamePhotonService _gamePhotonService;
        private Character _character;
        private GameBoard _gameBoard;
        
        [Inject]
        private void Construct(GamePhotonService gamePhotonService, Character character,
            GameBoard gameBoard)
        {
            _gamePhotonService = gamePhotonService;
            _character = character;
            _gameBoard = gameBoard;
            
            Spawn();
        }

        private void Spawn()
        {
            _gamePhotonService.RegisterCharacter(_character);
            _character.Initialize();
            _character.SetPosition(_gameBoard.GetRandomSpawnPoint());
            _character.Activate();
        }
    }
}