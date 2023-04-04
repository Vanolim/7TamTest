using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class BootstrapperInstaller : MonoInstaller,
        Zenject.IInitializable
    {
        [SerializeField]
        private ServerClient _serverClient;

        [SerializeField]
        private LoadingUIContext _loadingUIContext;
        
        private readonly List<IInitializable> _initializables = new();
        
        public override void InstallBindings()
        {
            BindPrefab(_serverClient);
            BindPrefab(_loadingUIContext);
            BindInstance(new Bootstrapper());
            
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