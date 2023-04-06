using UnityEngine;

namespace TapTest
{
    public class Bullet : MonoBehaviour,
        IActivable
    {
        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}