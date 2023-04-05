using System;
using UnityEngine;
using Zenject;

namespace TapTest
{
    public class InputAdapter : IInitializable,
        IActivable,
        IDisposable,
        ITickable
    {
        private CharacterSpawner _characterSpawner;
        private CharacterGun _characterGun;
        private CharacterMovement _characterMovement;
        private CharacterInput _characterInput;
        private CharacterInput.CharacterActions _mapInput;
        private TickableService _tickableService;
        
        [Inject]
        private void Construct(CharacterSpawner characterSpawner, TickableService tickableService)
        {
            _tickableService = tickableService;
            _characterSpawner = characterSpawner;
            _characterSpawner.OnSpawn += SetCharacter;
        }

        private void SetCharacter(Character character)
        {
            _characterGun = character.CharacterGun;
            _characterMovement = character.CharacterMovement;
        }

        public void Tick(float dt) => 
            _characterMovement.Move(_characterInput.Character.Move.ReadValue<Vector2>());

        private void Shoot() => _characterGun.TryShoot();

        public void Initialize()
        {
            _tickableService.Add(this);
            
            _characterInput = new CharacterInput();
            _characterInput.Enable();
            
            _mapInput = _characterInput.Character;
            _mapInput.Shoot.performed += _ => Shoot();
        }

        public void Activate() => _characterInput.Enable();

        public void Deactivate() => _characterInput.Disable();

        public void Dispose() => _characterSpawner.OnSpawn -= SetCharacter;
    }
}