using UnityEngine;

namespace TapTest
{
    public class BulletMovement : MonoBehaviour
    {
        private float _speed;

        private void Update()
        {
            transform.Translate(Vector3.up * _speed * Time.deltaTime);
        }

        public void Initialize(float movementSpeed) => _speed = movementSpeed;
    }
}