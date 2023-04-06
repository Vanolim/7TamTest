using UnityEngine;

namespace TapTest
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _rb;
        
        [SerializeField]
        private float _speedMovement;
        
        [SerializeField]
        private float _speedRotation;

        private Vector3 GetTargetPosition(Vector2 direction, float dt)
        {
            float directionMagnitude = Mathf.Clamp01(direction.magnitude);
            return transform.position +
                   (Vector3)direction * directionMagnitude * _speedMovement * dt;
        }

        private void RotateToTarget(Vector2 direction, float dt)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 
                _speedRotation * dt);
        }

        public void Move(Vector2 direction, float dt)
        {
            _rb.MovePosition(GetTargetPosition(direction,dt));
            RotateToTarget(direction, dt);
        }
    }
}