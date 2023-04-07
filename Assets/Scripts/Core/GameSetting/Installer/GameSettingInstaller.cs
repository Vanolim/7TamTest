using UnityEngine;
using Zenject;

namespace TapTest
{
    public class GameSettingInstaller : MonoInstaller
    {
        [SerializeField]
        private GameSetting _gameSetting;
        
        public override void InstallBindings()
        {
            BindInstance(_gameSetting);
        }
        
        private void BindInstance<T>(T instance) =>
            this.BindInstance(Container, instance);
    }
}