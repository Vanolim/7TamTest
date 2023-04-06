using UnityEngine;
using Zenject;

namespace TapTest
{
    public class CharacterHealth : MonoBehaviour,
        IDamageable,
        IInitializable
    {
        [SerializeField]
        private CharacterHealthView _characterHealthView;
        
        private CharacterSetting _characterSetting;
        private float _maxValue;
        private float _currentValue;

        [Inject]
        private void Construct(CharacterSetting characterSetting)
        {
            _characterSetting = characterSetting;
        }

        public void TakeDamage(float value)
        {
            _currentValue -= value;
            _characterHealthView.UpdateHealthBar(_maxValue, _currentValue);
        }

        public void Initialize()
        {
            _maxValue = _characterSetting.InitHealth;
            _currentValue = _maxValue;
            _characterHealthView.UpdateHealthBar(_maxValue, _currentValue);
        }
    }
}