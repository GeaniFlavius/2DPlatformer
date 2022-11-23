using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Input input;
    public InputAction movementInput;
    public InputAction mousePosition;
    private Jump jump;
    private RangeAttack _rangeAttack;
    private Move move;
    private Look look;
    private Flip flip;
    private Dash dash;
    private void Awake()
    {
        input = new Input();
        jump = GetComponent<Jump>();
        _rangeAttack = GetComponentInChildren<RangeAttack>();
        move = GetComponent<Move>();
        look = GetComponent<Look>();
        flip = GetComponent<Flip>();
        dash = GetComponent<Dash>();
    }

    private void OnEnable()
    {
        input.Player.Move.Enable();
        input.Player.Look.Enable();
        input.Player.Jump.Enable();
        input.Player.Dash.Enable();
        input.Player.AttackOnHold.Enable();
        input.Player.AttackOnRelease.Enable();
        input.Player.AttackOnDoubleTap.Enable(); // TODO does not work
        
        input.Player.Jump.performed += Jump;
        input.Player.Dash.performed += Dash;
        input.Player.AttackOnHold.performed += AttackOnHold;
        input.Player.AttackOnRelease.performed += AttackOnRelease;
        input.Player.AttackOnDoubleTap.performed += AttackOnDoubleTap;
        
        movementInput = input.Player.Move;
        mousePosition = input.Player.Look;
    }

    private void OnDisable()
    {
        movementInput.Disable();
        mousePosition.Disable();
        input.Player.Jump.Disable();
        input.Player.Dash.Disable();
        input.Player.AttackOnHold.Disable();
        input.Player.AttackOnRelease.Disable();
        input.Player.AttackOnDoubleTap.Disable(); // TODO does not work
    }
    
    private void FixedUpdate()
    {
        Move();
        Look();
        Flip();
    }
    
    private void AttackOnRelease(InputAction.CallbackContext context)
    {
        _rangeAttack.ShootOnRelease();
    }
    
    private void AttackOnHold(InputAction.CallbackContext context)
    {
        _rangeAttack.ShootOnHold();
    }
    
    private void AttackOnDoubleTap(InputAction.CallbackContext context)
    {
        _rangeAttack.ShootOnDoubleTap();
    }

    private void Move()
    {
        move.HorizontalMove(movementInput.ReadValue<Vector2>());
    }
    private void Jump(InputAction.CallbackContext context) {
        jump.DoJump();
    }
    private void Look()
    {
        look.LookDirection(mousePosition.ReadValue<Vector2>());
    }

    private void Flip()
    {
        flip.Rotate(mousePosition.ReadValue<Vector2>());
    }

    private void Dash(InputAction.CallbackContext context)
    {
        dash.DoDash(mousePosition.ReadValue<Vector2>());
    }
}