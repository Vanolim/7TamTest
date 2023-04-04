using UnityEngine;
using Zenject;

namespace TapTest
{
    public class SceneLoaderInstaller : MonoInstaller
    {
        [SerializeField]
        private SceneLoader _corePrefab;

        [SerializeField]
        private SceneLoaderView _sceneLoaderView;

        public override void InstallBindings()
        {
            BindPrefab(_sceneLoaderView);
            BindPrefab(_corePrefab);
        }
        
        private void BindPrefab<T>(T prefab) where T : MonoBehaviour =>
            this.BindPrefab(Container, prefab);
    }
}