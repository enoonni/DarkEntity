using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemHandler : MonoBehaviour
{
    public static InputSystemHandler Instance{get; private set;}
    private InputSystem _inputSystem;

    public Vector2 MoveDirection {get; private set;}

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _inputSystem = new InputSystem();
        MoveDirection = new Vector2();
    }

    private void OnEnable()
    {
        _inputSystem.Enable();

        _inputSystem.Player.Move.performed += OnMovePerformed;
        _inputSystem.Player.Move.canceled += OnMoveCancelled;
    }

    private void OnDisable()
    {
        _inputSystem.Disable();

        _inputSystem.Player.Move.performed -= OnMovePerformed;
        _inputSystem.Player.Move.canceled -= OnMoveCancelled;
    }

     private void OnMovePerformed(InputAction.CallbackContext context)
    {
        MoveDirection = context.ReadValue<Vector2>();
    }

    private void OnMoveCancelled(InputAction.CallbackContext context)
    {
        MoveDirection = Vector2.zero;
    }
}
