using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CharacterColor : MonoBehaviour,
        IInitializable
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        
        private PhotonView _photonView;
        private Color _color;

        private void SetRandomColor()
        {
            _color = Random.ColorHSV();
            _photonView.RPC("SetColor", RpcTarget.AllBuffered, 
                new Vector3(_color.r, _color.g, _color.b));
        }

        private float GetRandomValue() => Random.Range(0f, 1f);

        [PunRPC]
        private void SetColor(Vector3 color) => 
            _spriteRenderer.color = new Color(color.x, color.y, color.z);
        
        public void Initialize()
        {
            _photonView = GetComponent<PhotonView>();
            SetRandomColor();
        }
    }
}