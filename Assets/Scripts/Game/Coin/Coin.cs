using UnityEngine;

namespace TapTest
{
    public class Coin : MonoBehaviour
    {
        public void SetPosition(Vector2 position) => transform.position = position;
    }
}