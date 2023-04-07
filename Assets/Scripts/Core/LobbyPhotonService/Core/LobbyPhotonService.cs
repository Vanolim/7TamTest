using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class LobbyPhotonService : MonoBehaviourPunCallbacks
    {
        private SceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public override void OnMasterClientSwitched(Player newMasterClient)
        {
            Debug.Log("Swithed");
            LeaveRoom();
        }

        public void CreateRoom(string roomName, RoomOptions roomOptions) => 
            PhotonNetwork.CreateRoom(roomName, roomOptions);

        public void JoinRoom(string roomName) => 
            PhotonNetwork.JoinRoom(roomName);

        public void LeaveRoom()
        {
            PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            _sceneLoader.Load(LoadableScene.Lobby);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Joined");
            PhotonNetwork.LoadLevel("Game");
        }
    }
}