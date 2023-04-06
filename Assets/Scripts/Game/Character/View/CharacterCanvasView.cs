using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TapTest
{
    public class CharacterCanvasView : MonoBehaviour
    {
        [SerializeField]
        private Transform _pivot;
        
        [SerializeField]
        private Image _health;

        [SerializeField]
        private TMP_Text _coin;
        
        private void LateUpdate()
        {
            UpdateHealthViewTransform();
        }

        private void UpdateHealthViewTransform()
        {
            transform.position = _pivot.position;
            transform.rotation = Quaternion.identity;
        }

        public void UpdateHealthBar(float delta) => _health.fillAmount = delta;

        public void UpdateCoinWallet(int value) => _coin.text = value.ToString();
    }
}