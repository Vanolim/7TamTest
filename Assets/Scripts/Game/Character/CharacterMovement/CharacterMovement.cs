using UnityEngine;

namespace TapTest
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speedMovement;
        
        [SerializeField]
        private float _speedRotation;

        public void Move(Vector2 direction, float dt)
        {
            float directionMagnitude = Mathf.Clamp01(direction.magnitude);
            transform.Translate(direction * _speedMovement * directionMagnitude * dt, Space.World);
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, _speedRotation * dt);
        }
    }
}