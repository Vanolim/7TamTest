using System;
using Photon.Realtime;
using Zenject;

namespace TapTest
{
    public class Lobby : IInitializable,
        IDisposable
    {
        private LobbyPhotonService _photonService;
        private RoomOptions _roomOptions;
        private LobbyUIContext _lobbyUIContext;

        [Inject]
        private void Construct(LobbyPhotonService photonService, LobbyUIContext lobbyUIContext)
        {
            _photonService = photonService;
            _lobbyUIContext = lobbyUIContext;
        }
        
        private void CreateLobby(string roomName)
        {
            _roomOptions = new RoomOptions();
            _photonService.CreateRoom(roomName, _roomOptions);
        }

        private void JoinLobby(string roomName)
        {
            _photonService.JoinRoom(roomName);
        }

        public void Initialize()
        {
            _lobbyUIContext.LobbyCreatorView.OnCreate += CreateLobby;
            _lobbyUIContext.LobbyJoinView.OnJoin += JoinLobby;
        }

        public void Dispose()
        {
            _lobbyUIContext.LobbyCreatorView.OnCreate -= CreateLobby;
            _lobbyUIContext.LobbyJoinView.OnJoin -= JoinLobby;
        }
    }
}