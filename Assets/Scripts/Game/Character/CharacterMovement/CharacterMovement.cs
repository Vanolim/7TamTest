using UnityEngine;
using Zenject;

namespace TapTest
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour,
        IInitializable
    {
        private Rigidbody2D _rb;
        private CharacterSetting _characterSetting;

        [Inject]
        private void Construct(CharacterSetting characterSetting)
        {
            _characterSetting = characterSetting;
        }

        private Vector3 GetTargetPosition(Vector2 direction, float dt)
        {
            float directionMagnitude = Mathf.Clamp01(direction.magnitude);
            return transform.position +
                   (Vector3)direction * directionMagnitude * _characterSetting.MovementSpeed * dt;
        }

        private void RotateToTarget(Vector2 direction, float dt)
        {
            Quaternion toRotate = Quaternion.LookRotation(Vector3.forward, direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, 
                _characterSetting.RotationSpeed * dt);
        }

        public void Move(Vector2 direction, float dt)
        {
            _rb.MovePosition(GetTargetPosition(direction,dt));
            RotateToTarget(direction, dt);
        }

        public void Initialize()
        {
            _rb = gameObject.GetComponent<Rigidbody2D>();
        }
    }
}