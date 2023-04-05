using Photon.Pun;
using UnityEngine;

namespace TapTest
{
    public class CharacterMovement : MonoBehaviour
    {
        public void Move(Vector2 moveDirection)
        {
            Debug.Log(moveDirection);
        }
    }
}