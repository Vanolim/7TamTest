using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class Wall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out IDoingDamage doingDamage))
            {
                PhotonNetwork.Destroy(doingDamage.Object);
            }
        }
    }
}