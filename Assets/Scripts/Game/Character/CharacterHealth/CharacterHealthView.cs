using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class CharacterHealthView : MonoBehaviour
    {
        [SerializeField]
        private Transform _pivot;
        
        [SerializeField]
        private Image _image;
        
        private void LateUpdate()
        {
            UpdateHealthViewTransform();
        }

        private void UpdateHealthViewTransform()
        {
            transform.position = _pivot.position;
            transform.rotation = Quaternion.identity;
        }

        public void UpdateHealthBar(float maxHealth, float currentHealth)
        {
            Debug.Log($"{maxHealth} -- {currentHealth}");
            _image.fillAmount = currentHealth / maxHealth;
        }
    }
}