using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private Vector2 movementInput;
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        Debug.Log("On movement Input");
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        Debug.Log("On jump input");
        if (context.started)
        {
            Debug.Log("Jump button pushed down now");
        }
        if (context.performed)
        {
            Debug.Log("Jump is beign held down");
        }
        if (context.canceled)
        {
            Debug.Log("Jump button has been released");
        }
    }
}
