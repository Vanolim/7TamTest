using System;
using UnityEngine;

namespace TapTest
{
    public class Coin : MonoBehaviour
    {
        public event Action<Coin> OnTacken;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.TryGetComponent(out Character character))
            {
                OnTacken?.Invoke(this);
            }
        }

        public void SetPosition(Vector2 position) => transform.position = position;
    }
}