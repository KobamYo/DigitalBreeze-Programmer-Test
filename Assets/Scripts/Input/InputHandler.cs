using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput {get; private set;}

    public bool JumpPressed {get; private set;}
    public bool AttackPressed {get; private set;}
    public bool ThrowPressed {get; private set;}
    public bool SlidePressed {get; private set;}

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) JumpPressed = true;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed) AttackPressed = true;
    }

    public void OnThrow(InputAction.CallbackContext context)
    {
        if (context.performed) ThrowPressed = true;
    }

    public void OnSlide(InputAction.CallbackContext context)
    {
        if (context.performed) SlidePressed = true;
    }

    public void ClearOneShotFlags()
    {
        JumpPressed = false;
        AttackPressed = false;
        ThrowPressed = false;
        SlidePressed = false;
    }
}
