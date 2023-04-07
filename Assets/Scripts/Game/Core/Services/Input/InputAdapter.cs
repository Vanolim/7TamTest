using UnityEngine;
using Zenject;

namespace TapTest
{
    public class InputAdapter : IActivable,
        IFixedTickable
    {
        private CharacterSpawner _characterSpawner;
        private CharacterGun _characterGun;
        private CharacterMovement _characterMovement;
        private CharacterInput _characterInput;
        private CharacterInput.CharacterActions _mapInput;
        private TickableService _tickableService;
        private InputPanel _inputPanel;
        
        [Inject]
        private void Construct(Character character, TickableService tickableService,
            InputPanel inputPanel)
        {
            _tickableService = tickableService;
            _inputPanel = inputPanel;
            SetCharacter(character);
            InitCharacterInput();
        }

        private void SetCharacter(Character character)
        {
            _characterGun = character.CharacterGun;
            _characterMovement = character.CharacterMovement;
        }

        public void Tick(float dt)
        {
            Vector2 inputDirection = _characterInput.Character.Move.ReadValue<Vector2>();
            if (inputDirection != Vector2.zero)
            {
                _characterMovement.Move(_characterInput.Character.Move.ReadValue<Vector2>(), dt);
            }
        }

        private void Shoot()
        {
            _characterGun.TryShoot();
        }

        private void InitCharacterInput()
        {
            _tickableService.Add(this);
            
            _characterInput = new CharacterInput();

            _mapInput = _characterInput.Character;
            _mapInput.Shoot.performed += _ => Shoot();
        }

        public void Activate()
        {
            _characterInput.Enable();
            _inputPanel.Activate();
        }

        public void Deactivate()
        {
            _characterInput.Disable();
            _inputPanel.Deactivate();
        }
    }
}