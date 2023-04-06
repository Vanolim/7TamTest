using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class GameBoard : MonoBehaviour
    {
        [SerializeField]
        private PhotonView _photonView;

        public void TrySpawn()
        {
            if (_photonView.IsMine)
            {
                
            }
        }
    }
}