using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterColor : MonoBehaviour,
        IInitializable
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
            SetRandomColor();
        }
    }
}