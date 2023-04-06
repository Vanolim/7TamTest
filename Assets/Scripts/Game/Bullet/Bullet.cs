using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class Bullet : MonoBehaviour,
        IActivable
    {
        [field: SerializeField]
        public PhotonView PhotonView { get; private set; }
        
        public void SetPosition(Transform position)
        {
            transform.position = position.position;
            transform.up = position.up;
        }

        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}