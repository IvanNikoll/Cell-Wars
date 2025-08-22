using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// This class processes user's interaction with the app
/// </summary>
public class ClickHandler : MonoBehaviour
{
    public event Action<CellView> Click;
    private NewActions _inputActions;

    private void Awake()
    {
        _inputActions = new NewActions();
    }

    private void OnEnable()
    {
        _inputActions.Player.Click.performed += OnClick;
        _inputActions.Player.Enable();
    }

    private void OnDisable()
    {
        _inputActions.Player.Click.performed -= OnClick;
        _inputActions.Player.Disable();
    }

    private void OnClick(InputAction.CallbackContext ctx)
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            hit.collider.TryGetComponent<CellView>(out CellView cellView);
            if (cellView != null)
            {
                Click?.Invoke(cellView);
            }
            else
            {
                Click?.Invoke(null);
            }
        }
    }
}
