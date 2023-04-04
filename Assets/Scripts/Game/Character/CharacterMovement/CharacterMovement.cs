using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CharacterMovement : MonoBehaviour
    {
        private PhotonView _photonView;
        
        private void Update()
        {
            if (_photonView.IsMine)
            {
                
            }
        }
    }
}