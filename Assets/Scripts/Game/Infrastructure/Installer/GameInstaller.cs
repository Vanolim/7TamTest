using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class GameInstaller : MonoInstaller,
        Zenject.IInitializable
    {
        [SerializeField]
        private GameProvider _gameProvider;
        
        private readonly List<IInitializable> _initializables = new();
        
        public override void InstallBindings()
        {
            BindPrefab(_gameProvider.Character);
            BindPrefab(_gameProvider.GamePhotonService);
            BindInstance(_gameProvider.CharacterSetting);
            BindInstance(new CharacterSpawner());
            BindInstance(new InputAdapter());
            
            BindPrefab(_gameProvider.Spawner);
            BindPrefab(_gameProvider.TickableService);
            BindPrefab(_gameProvider.InputPanel);

            this.BindThis(Container, this);
        }
        
        private void BindPrefab<T>(T prefab) where T : MonoBehaviour =>
            this.BindPrefab(Container, prefab);

        private void BindInstance<T>(T instance) =>
            this.BindInstance(Container, instance, _initializables);

        public void Initialize()
        {
            foreach (var initializable in _initializables)
            {
                initializable.Initialize();
            }
        }
    }
}