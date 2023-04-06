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
            Move();
        }

        private void Move() => _rb.MovePosition(_rb.transform.localPosition +
                                                GetTargetDirection() * _speed * Time.fixedDeltaTime);

        private Vector3 GetTargetDirection() => transform.TransformDirection(Vector3.up);
    }
}