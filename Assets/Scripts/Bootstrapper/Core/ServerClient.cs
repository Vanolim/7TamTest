using System;
using Photon.Pun;

namespace TapTest
{
    public class ServerClient : MonoBehaviourPunCallbacks
    {
        public event Action OnConnect;

        public void Connect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public override void OnConnectedToMaster()
        {
            OnConnect?.Invoke();
        }
    }
}