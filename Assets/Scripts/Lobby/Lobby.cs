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
            if (IsPlayerNameEnter(out string playerName))
            {
                PhotonNetwork.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
                _roomOptions = new RoomOptions();
                _photonService.CreateRoom(roomName, _roomOptions);
            }
        }

        private void JoinRoomRoom(string roomName)
        {
            if (IsPlayerNameEnter(out string playerName))
            {
                PhotonNetwork.NickName = playerName;
                PhotonNetwork.ConnectUsingSettings();
                _photonService.JoinRoom(roomName);
            }
        }

        private bool IsPlayerNameEnter(out string playerName)
        {
            playerName = _lobbyUIContext.LobbyNameView.PlayerName.text;
            return playerName != "";
        }

        public void Initialize()
        {
            _lobbyUIContext.LobbyCreatorView.OnCreate += CreateRoom;
            _lobbyUIContext.LobbyJoinView.OnJoinRoom += JoinRoomRoom;
        }

        public void Dispose()
        {
            _lobbyUIContext.LobbyCreatorView.OnCreate -= CreateRoom;
            _lobbyUIContext.LobbyJoinView.OnJoinRoom -= JoinRoomRoom;
        }
    }
}