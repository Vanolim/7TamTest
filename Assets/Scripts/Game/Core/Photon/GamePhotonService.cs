using System;
using Photon.Pun;
using Photon.Realtime;

namespace TapTest
{
    public class GamePhotonService : MonoBehaviourPunCallbacks
    {
        public event Action OnLeaveRoom;
        
        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }

        public override void OnLeftRoom()
        {
            OnLeaveRoom?.Invoke();
        }

        public override void OnPlayerEnteredRoom(Player player)
        {
            
        }
        
        public override void OnPlayerLeftRoom(Player player)
        {
            
        }
    }
}