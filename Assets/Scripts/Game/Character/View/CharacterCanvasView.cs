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
        
        [SerializeField]
        private TMP_Text _name;
        
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
        public void UpdateCoinWallet(int coinValue) => _coin.text = coinValue.ToString();
        public void UpdatePlayerName(string playerName) => _name.text = playerName;
    }
}