using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterColor : MonoBehaviour,
        IInitializable,
        IPunObservable
    {
        private SpriteRenderer _spriteRenderer;

        private void SetRandomColor()
        {
            _spriteRenderer.color = new Color(
                GetRandomValue(),
                GetRandomValue(),
                GetRandomValue());
        }

        private float GetRandomValue() => Random.Range(0f, 1f);
        
        public void Initialize()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            SetRandomColor();
        }

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(_spriteRenderer);
            }
            else
            {
                _spriteRenderer = (SpriteRenderer)stream.ReceiveNext();
            }
        }
    }
}