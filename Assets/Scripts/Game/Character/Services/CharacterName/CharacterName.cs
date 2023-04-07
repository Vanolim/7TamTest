using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(PhotonView))]
    public class CharacterName : MonoBehaviour,
        IInitializable
    {
        [SerializeField]
        private CharacterCanvasView _characterCanvasView;
        
        private PhotonView _photonView;

        [PunRPC]
        private void RPC_SetPlayerName(string name) =>
            _characterCanvasView.UpdatePlayerName(name);
        
        public void Initialize()
        {
            _photonView = gameObject.GetComponent<PhotonView>();
            _photonView.RPC("RPC_SetPlayerName", RpcTarget.AllBuffered, 
                PhotonNetwork.NickName);
        }
    }
}