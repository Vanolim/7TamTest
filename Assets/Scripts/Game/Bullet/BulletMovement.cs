using UnityEngine;

namespace TapTest
{
    public class BulletMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private void Update()
        {
            Move();
        }

        private void Move() => transform.Translate(Vector3.up * _speed * Time.deltaTime);

        private Vector3 GetTargetDirection() => transform.TransformDirection(Vector3.up);
    }
}