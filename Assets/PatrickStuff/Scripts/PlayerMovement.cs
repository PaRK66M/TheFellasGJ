using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //Input
    private PlayerControls playerInputSystem;

    //Components
    private Rigidbody2D rb;

    //Movement
    [SerializeField]
    private float speed;
    private float horizontalMovmentInput;

    // Start is called before the first frame update
    void Start()
    {
        playerInputSystem = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();

        horizontalMovmentInput = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 displacement = rb.position;
        displacement.x += horizontalMovmentInput + speed * Time.fixedDeltaTime;

        rb.MovePosition(displacement);
    }

    #region Input
    private void EnableInput()
    {
        playerInputSystem.Enable();
        playerInputSystem.PlayerMap.HorizontalMovement.performed += OnHorizontalMovementPerformed;
        playerInputSystem.PlayerMap.HorizontalMovement.canceled += OnHorizontalMovementCancelled;

    }

    private void DisableInput()
    {
        playerInputSystem.Disable();
    }

    private void OnHorizontalMovementPerformed(InputAction.CallbackContext direction)
    {
        horizontalMovmentInput = direction.ReadValue<float>();
    }

    private void OnHorizontalMovementCancelled(InputAction.CallbackContext direction) 
    {
        horizontalMovmentInput = 0.0f;
    }
    #endregion
}
