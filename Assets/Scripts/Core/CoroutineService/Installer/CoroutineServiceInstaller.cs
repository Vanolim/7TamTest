using Zenject;

namespace TapTest
{
    public class CoroutineServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInstance(new CoroutineService(this));
        }
        
        private void BindInstance<T>(T instance) =>
            this.BindInstance(Container, instance);
    }
}
