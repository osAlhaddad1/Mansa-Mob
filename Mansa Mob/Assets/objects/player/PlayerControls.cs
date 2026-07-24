using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerControls _controls;
    
    private Vector2 _moveInput;
    private bool _jumpInput;

    public Vector2 MoveInput => _moveInput;
    public bool JumpInput => _jumpInput;

    private void Awake()
    {
        // Instantiate the auto-generated class
        _controls = new PlayerControls();

        // Move Input Bindings
        _controls.Player.Move.performed += ctx => _moveInput = ctx.ReadValue<Vector2>();
        _controls.Player.Move.canceled += ctx => _moveInput = Vector2.zero;

        // Jump Input Bindings
        _controls.Player.Jump.started += ctx => _jumpInput = true;
        _controls.Player.Jump.canceled += ctx => _jumpInput = false;
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    /// <summary>
    /// Resets the jump input. Must be called by the locomotion script 
    /// after processing the jump to prevent multi-frame triggering.
    /// </summary>
    public void ConsumeJump()
    {
        _jumpInput = false;
    }
}