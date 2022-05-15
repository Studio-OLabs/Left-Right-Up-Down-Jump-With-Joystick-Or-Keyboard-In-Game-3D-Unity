using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody sphereRigidbody;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
       sphereRigidbody = GetComponent<Rigidbody>();
       playerInput = GetComponent<PlayerInput>();

       playerInputActions = new PlayerInputActions();
       playerInputActions.Player.Enable();
       playerInputActions.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Debug.Log(inputVector);
        float speed = 1f;
        sphereRigidbody.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }
   
    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)

        {
            Debug.Log("Jump! " + context.phase);
            sphereRigidbody.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
       
    }
  
}