using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class LobbyInstaller : MonoInstaller,
        Zenject.IInitializable
    {
        [SerializeField]
        private LobbyUIContext _lobbyUIContext;

        private readonly List<IInitializable> _initializables = new();

        public override void InstallBindings()
        {
            BindPrefab(_lobbyUIContext);
            BindInstance(new Lobby());
            
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