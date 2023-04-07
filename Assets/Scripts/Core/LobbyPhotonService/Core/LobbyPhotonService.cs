using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace TapTest
{
    public class LobbyPhotonService : MonoBehaviourPunCallbacks
    {
        public void CreateRoom(string roomName, RoomOptions roomOptions) => 
            PhotonNetwork.CreateRoom(roomName, roomOptions);

        public void JoinRoom(string roomName) => 
            PhotonNetwork.JoinRoom(roomName);

        public void LeaveRoom() => 
            PhotonNetwork.LeaveRoom();

        public void LoadLobby() => 
            PhotonNetwork.LoadLevel("Lobby");

        public override void OnJoinedRoom() => 
            PhotonNetwork.LoadLevel("Game");
    }
}