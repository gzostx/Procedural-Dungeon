using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GatherInputs : MonoBehaviour
{
    private Controls _controls;
    [SerializeField] private Vector2 _value;

    public Vector2 Value => _value;

    private void Awake()
    {
        _controls = new Controls();
    }
    
    private void OnEnable()
    {
        _controls.Player.Move.performed += StartMove;
        _controls.Player.Move.canceled += StopMove;
        _controls.Player.Enable();
    }
    
    private void StartMove(InputAction.CallbackContext obj)
    {
        _value = obj.ReadValue<Vector2>().normalized;
    }
    private void StopMove(InputAction.CallbackContext obj)
    {
        _value = Vector2.zero;
    }
    
    private void OnDisable()
    {
        _controls.Player.Move.performed -= StartMove;
        _controls.Player.Move.canceled -= StopMove;
        _controls.Player.Disable();
    }
}
