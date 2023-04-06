using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private Rigidbody2D _rb;

        private void FixedUpdate()
        {
            _rb.MovePosition(
                transform.position + Vector3.forward * _speed * Time.fixedDeltaTime);
        }
    }
}