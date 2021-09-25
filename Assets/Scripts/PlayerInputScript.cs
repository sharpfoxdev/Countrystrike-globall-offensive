// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputScript : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputScript()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Basic"",
            ""id"": ""a773e0dd-2195-4d10-9df8-ee06abf92d30"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""afa80966-5ca0-4096-bdb6-d4336e1fb588"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a416426a-f8d1-4c78-a740-bc1ad157d122"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""b5f8ee83-c15a-40d4-a2ef-f1508a7079bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""7811d9ba-2098-4114-a278-9df9f74d3b80"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""fb03ce4c-e767-4386-acc3-a6e3f2ad14d0"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""9e6afe19-7251-4a26-a638-ef4665f08249"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""65c5a3ac-a9de-4ffc-941c-e6d837294e1f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerNet"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""935dd963-ef89-4a6e-922d-555bcbaaf064"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""737096f8-f75f-4c3b-be14-e242114046f9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerNet"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""9553c2a7-8049-4486-8ca6-49c4c5090253"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4a559e08-4f01-4c8c-8b13-0dd262e57471"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player3"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""373f1ec7-1560-473d-aa49-80935837eb16"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player3"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""8ccd9182-6b99-4381-bfcf-96974a193cf7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""43563097-4e0c-42f8-85ff-fe673e5dc479"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""990c93ef-bf29-4921-8965-58ddbb4d8f94"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player2"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftRight"",
                    ""id"": ""6d74e3b0-d091-4706-b512-6437fcc09f36"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""15cca272-657e-4930-a741-11e79c80bc19"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""e009808f-4523-421f-9f62-0f9bf191814f"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player4"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""557d879d-cb7d-4124-8eac-383cceca4b8a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c0c2f67e-ed86-4399-b7a2-b0b981457ea9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerNet"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b39ed24d-604d-4633-bceb-ff6822455a05"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player3"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afbfc31e-b603-4942-ab69-e9065f524235"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player2"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee0a142-1f64-47df-b10b-729b0822758d"",
                    ""path"": ""<Keyboard>/numpad8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player4"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fb7055d-3874-489b-ac1b-dc0a21978dab"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbb322f2-3671-4973-979c-f932f9b74fb2"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerNet"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a39ca4fc-630e-4058-8439-f6cc662dc779"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player2"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bfc9db3e-ee4b-4b9b-9eb2-d7a446030e75"",
                    ""path"": ""<Keyboard>/rightCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player3"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9becf97-dd57-4181-93fb-fd4a8a82dc40"",
                    ""path"": ""<Keyboard>/numpad0"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player4"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb4e0359-7160-498c-959f-b9ee8ec38706"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player1"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1999591d-3047-4296-89e9-38c660c95514"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PlayerNet"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8342f1a6-3582-45e1-96ab-9a5dc266d0c9"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player2"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d46cafe5-4520-423c-ada6-47dd337a66ab"",
                    ""path"": ""<Keyboard>/rightShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player3"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ca5ac9f0-4b85-4859-914a-892d527cedd0"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player4"",
                    ""action"": ""ChangeWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player1"",
            ""bindingGroup"": ""Player1"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""bindingGroup"": ""Player2"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Player3"",
            ""bindingGroup"": ""Player3"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Player4"",
            ""bindingGroup"": ""Player4"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""PlayerNet"",
            ""bindingGroup"": ""PlayerNet"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Basic
        m_Basic = asset.FindActionMap("Basic", throwIfNotFound: true);
        m_Basic_Movement = m_Basic.FindAction("Movement", throwIfNotFound: true);
        m_Basic_Jump = m_Basic.FindAction("Jump", throwIfNotFound: true);
        m_Basic_Shoot = m_Basic.FindAction("Shoot", throwIfNotFound: true);
        m_Basic_ChangeWeapon = m_Basic.FindAction("ChangeWeapon", throwIfNotFound: true);
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

    // Basic
    private readonly InputActionMap m_Basic;
    private IBasicActions m_BasicActionsCallbackInterface;
    private readonly InputAction m_Basic_Movement;
    private readonly InputAction m_Basic_Jump;
    private readonly InputAction m_Basic_Shoot;
    private readonly InputAction m_Basic_ChangeWeapon;
    public struct BasicActions
    {
        private @PlayerInputScript m_Wrapper;
        public BasicActions(@PlayerInputScript wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Basic_Movement;
        public InputAction @Jump => m_Wrapper.m_Basic_Jump;
        public InputAction @Shoot => m_Wrapper.m_Basic_Shoot;
        public InputAction @ChangeWeapon => m_Wrapper.m_Basic_ChangeWeapon;
        public InputActionMap Get() { return m_Wrapper.m_Basic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicActions set) { return set.Get(); }
        public void SetCallbacks(IBasicActions instance)
        {
            if (m_Wrapper.m_BasicActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnJump;
                @Shoot.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnShoot;
                @ChangeWeapon.started -= m_Wrapper.m_BasicActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.performed -= m_Wrapper.m_BasicActionsCallbackInterface.OnChangeWeapon;
                @ChangeWeapon.canceled -= m_Wrapper.m_BasicActionsCallbackInterface.OnChangeWeapon;
            }
            m_Wrapper.m_BasicActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @ChangeWeapon.started += instance.OnChangeWeapon;
                @ChangeWeapon.performed += instance.OnChangeWeapon;
                @ChangeWeapon.canceled += instance.OnChangeWeapon;
            }
        }
    }
    public BasicActions @Basic => new BasicActions(this);
    private int m_Player1SchemeIndex = -1;
    public InputControlScheme Player1Scheme
    {
        get
        {
            if (m_Player1SchemeIndex == -1) m_Player1SchemeIndex = asset.FindControlSchemeIndex("Player1");
            return asset.controlSchemes[m_Player1SchemeIndex];
        }
    }
    private int m_Player2SchemeIndex = -1;
    public InputControlScheme Player2Scheme
    {
        get
        {
            if (m_Player2SchemeIndex == -1) m_Player2SchemeIndex = asset.FindControlSchemeIndex("Player2");
            return asset.controlSchemes[m_Player2SchemeIndex];
        }
    }
    private int m_Player3SchemeIndex = -1;
    public InputControlScheme Player3Scheme
    {
        get
        {
            if (m_Player3SchemeIndex == -1) m_Player3SchemeIndex = asset.FindControlSchemeIndex("Player3");
            return asset.controlSchemes[m_Player3SchemeIndex];
        }
    }
    private int m_Player4SchemeIndex = -1;
    public InputControlScheme Player4Scheme
    {
        get
        {
            if (m_Player4SchemeIndex == -1) m_Player4SchemeIndex = asset.FindControlSchemeIndex("Player4");
            return asset.controlSchemes[m_Player4SchemeIndex];
        }
    }
    private int m_PlayerNetSchemeIndex = -1;
    public InputControlScheme PlayerNetScheme
    {
        get
        {
            if (m_PlayerNetSchemeIndex == -1) m_PlayerNetSchemeIndex = asset.FindControlSchemeIndex("PlayerNet");
            return asset.controlSchemes[m_PlayerNetSchemeIndex];
        }
    }
    public interface IBasicActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnChangeWeapon(InputAction.CallbackContext context);
    }
}
