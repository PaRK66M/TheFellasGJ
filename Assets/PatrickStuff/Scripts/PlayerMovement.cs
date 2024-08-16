using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    //Input
    private PlayerControls playerInputSystem;

    //Components
    private Rigidbody2D rb;

    //Player
    public float minimumSize;

    //SpriteMap
    [SerializeField] private Tilemap groundMap;
    [SerializeField] private Tile flameTile;
    [SerializeField] private Transform frontStep;

    //Movement
    [SerializeField]
    private float speed;
    private float horizontalMovementInput;
    [SerializeField] 
    private float movementScaleDecrease;

    private float accelerationAmount;
    private float decelerationAmount;

    //Debug
    private Vector3 gizmoBox = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerInputSystem = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();

        horizontalMovementInput = 0.0f;

        accelerationAmount = (50 * speed) / speed;
        decelerationAmount = (50 * speed) / speed;

        EnableInput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        float targetSpeed = horizontalMovementInput * speed;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? accelerationAmount : decelerationAmount;

        float speedDifference = targetSpeed - rb.velocity.x;

        float movement = speedDifference * accelRate;

        rb.AddForce(movement * Vector2.right, ForceMode2D.Force);

        if (horizontalMovementInput > 0.0f)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMovementInput < 0.0f)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        if (movement != 0.0f)
        {
            Vector3Int temp = new Vector3Int(Mathf.FloorToInt(frontStep.position.x), Mathf.FloorToInt(frontStep.position.y - 0.1f), 0);
            gizmoBox = temp;
            groundMap.SetTile(temp, flameTile);
        }

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
        horizontalMovementInput = direction.ReadValue<float>();
    }

    private void OnHorizontalMovementCancelled(InputAction.CallbackContext direction) 
    {
        horizontalMovementInput = 0.0f;
    }
    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(new Vector3(gizmoBox.x + 0.5f, gizmoBox.y + 0.5f, 0.0f), Vector3.one);
    }

    #endregion
}
