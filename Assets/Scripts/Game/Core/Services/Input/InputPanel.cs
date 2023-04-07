using UnityEngine;

namespace TapTest
{
    public class InputPanel : MonoBehaviour,
        IActivable
    {
        [SerializeField]
        private Canvas _canvas;

        public void Activate() => _canvas.enabled = true;
        public void Deactivate() => _canvas.enabled = false;
    }
}