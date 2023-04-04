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
        private Color _currentColor;

        private void SetRandomColor()
        {
            Debug.Log(1111);
            
            _currentColor = new Color(
                GetRandomValue(),
                GetRandomValue(),
                GetRandomValue());
            
            _spriteRenderer.color = _currentColor;
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
                stream.SendNext(_currentColor);
            }
            else
            {
                Color color = (Color)stream.ReceiveNext();
                _spriteRenderer.color = color;
            }
        }
    }
}