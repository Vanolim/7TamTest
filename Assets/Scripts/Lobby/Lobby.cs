using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
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
        
        private void CreateRoom(string roomName)
        {
            PhotonNetwork.NickName = _lobbyUIContext.LobbyNameView.PlayerName.text;
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
            _roomOptions = new RoomOptions();
            _photonService.CreateRoom(roomName, _roomOptions);
        }

        private void JoinRoom(string roomName)
        {
            PhotonNetwork.NickName = _lobbyUIContext.LobbyNameView.PlayerName.text;
            PhotonNetwork.ConnectUsingSettings();
            _photonService.JoinRoom(roomName);
        }

        public void Initialize()
        {
            _lobbyUIContext.LobbyCreatorView.OnCreate += CreateRoom;
            _lobbyUIContext.LobbyJoinView.OnJoin += JoinRoom;
        }

        public void Dispose()
        {
            _lobbyUIContext.LobbyCreatorView.OnCreate -= CreateRoom;
            _lobbyUIContext.LobbyJoinView.OnJoin -= JoinRoom;
        }
    }
}