using UnityEngine;
using Zenject;

namespace TapTest
{
    public class Bootstrapper : IInitializable
    {
        private ServerClient _serverClient;
        private SceneLoader _sceneLoader;

        private const float _waitLoadScene = 1f;

        [Inject]
        private void Construct(ServerClient serverClient, SceneLoader sceneLoader)
        {
            _serverClient = serverClient;
            _sceneLoader = sceneLoader;

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