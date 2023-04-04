using UnityEngine;
using Zenject;

namespace TapTest
{
    public class LobbyPhotonServiceInstaller : MonoInstaller
    {
        [SerializeField]
        private LobbyPhotonService _corePrefab;

        public override void InstallBindings()
        {
            BindPrefab(_corePrefab);
        }
        
        private void BindPrefab<T>(T prefab) where T : MonoBehaviour =>
            this.BindPrefab(Container, prefab);
    }
}
