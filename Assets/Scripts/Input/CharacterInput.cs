//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Scripts/Input/CharacterInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace TapTest
{
    public partial class @CharacterInput : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @CharacterInput()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""CharacterInput"",
    ""maps"": [
        {
            ""name"": ""Character"",
            ""id"": ""31ed9505-ab7b-40ed-b29f-9e9d497592e4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""009a088f-751a-4208-a6c9-a11127aa8c40"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""d8867a00-ce83-4139-8b8f-c5468552bd5b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""45556c90-ed67-4c86-b409-1cbd0295ee87"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""884056a1-f95b-4502-a545-abe2c58175de"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Character
            m_Character = asset.FindActionMap("Character", throwIfNotFound: true);
            m_Character_Move = m_Character.FindAction("Move", throwIfNotFound: true);
            m_Character_Shoot = m_Character.FindAction("Shoot", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Character
        private readonly InputActionMap m_Character;
        private ICharacterActions m_CharacterActionsCallbackInterface;
        private readonly InputAction m_Character_Move;
        private readonly InputAction m_Character_Shoot;
        public struct CharacterActions
        {
            private @CharacterInput m_Wrapper;
            public CharacterActions(@CharacterInput wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Character_Move;
            public InputAction @Shoot => m_Wrapper.m_Character_Shoot;
            public InputActionMap Get() { return m_Wrapper.m_Character; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CharacterActions set) { return set.Get(); }
            public void SetCallbacks(ICharacterActions instance)
            {
                if (m_Wrapper.m_CharacterActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnMove;
                    @Shoot.started -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                    @Shoot.performed -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                    @Shoot.canceled -= m_Wrapper.m_CharacterActionsCallbackInterface.OnShoot;
                }
                m_Wrapper.m_CharacterActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Shoot.started += instance.OnShoot;
                    @Shoot.performed += instance.OnShoot;
                    @Shoot.canceled += instance.OnShoot;
                }
            }
        }
        public CharacterActions @Character => new CharacterActions(this);
        public interface ICharacterActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnShoot(InputAction.CallbackContext context);
        }
    }
}
