using UnityEngine;
using UnityEngine.InputSystem;

public class ComponentToggleInput : MonoBehaviour
{
    [SerializeField] Behaviour component;
    [SerializeField] InputAction inputAction;

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.performed += OnPerformed;
    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.performed -= OnPerformed;
    }

    private void OnPerformed(InputAction.CallbackContext _) => component.enabled = !component.enabled;
}
