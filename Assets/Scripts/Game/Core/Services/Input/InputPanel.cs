using UnityEngine;

namespace TapTest
{
    public class InputPanel : MonoBehaviour,
        IActivable
    {
        public void Activate() => gameObject.SetActive(true);
        public void Deactivate() => gameObject.SetActive(false);
    }
}