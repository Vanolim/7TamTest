using UnityEngine;

namespace TapTest
{
    public class SceneLoaderView : MonoBehaviour,
        IActivable
    {
        public void Activate() => gameObject.SetActive(true);
        
        public void Deactivate() => gameObject.SetActive(false);
    }
}