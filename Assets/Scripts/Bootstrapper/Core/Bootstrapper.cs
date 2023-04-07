using Zenject;

namespace TapTest
{
    public class Bootstrapper : IInitializable
    {
        private ServerClient _serverClient;
        private SceneLoader _sceneLoader;
        private float _waitLoadScene;

        [Inject]
        private void Construct(ServerClient serverClient, SceneLoader sceneLoader,
            GameSetting gameSetting)
        {
            _serverClient = serverClient;
            _sceneLoader = sceneLoader;
            _waitLoadScene = gameSetting.WaitBootstrapperScene;

            _serverClient.OnConnect += LoadLobby;
        }

        private void LoadLobby()
        {
            _sceneLoader.Load(LoadableScene.Lobby, _waitLoadScene);
        }

        public void Initialize()
        {
            _serverClient.Connect();
        }
    }
}