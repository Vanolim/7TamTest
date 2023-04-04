using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace TapTest
{
    public class LobbyPhotonService : MonoBehaviourPunCallbacks
    {
        public void CreateRoom(string roomName, RoomOptions roomOptions)
        {
            Debug.Log("Create");
            PhotonNetwork.CreateRoom(roomName, roomOptions);
        }

        public void JoinRoom(string roomName)
        {
            Debug.Log("Join");
            PhotonNetwork.JoinRoom(roomName);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined");
            PhotonNetwork.LoadLevel("Game");
        }

        public override void OnCreateRoomFailed(short returnCode, string message)
        {
            Debug.Log($"{returnCode} -- {message}");
            base.OnCreateRoomFailed(returnCode, message);
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.Log($"{returnCode} -- {message}");
            base.OnJoinRoomFailed(returnCode, message);
        }
    }
}