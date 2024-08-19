using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    //Input
    private PlayerControls playerInputSystem;

    //Components
    private Rigidbody2D rb;

    //Player
    public float minimumSize;
    public float enlargeScale;

    //SpriteMap
    [SerializeField] private Tilemap groundMap;
    [SerializeField] private Tilemap ashMap;
    [SerializeField] private Tile flameTile;
    [SerializeField] private Transform frontStep;
    private Vector3Int lastTilePosition;

    //Movement
    [SerializeField]
    private float speed;
    [SerializeField]
    private float verticalSpeed;
    private float horizontalMovementInput;
    private float verticalMovementInput;
    [SerializeField] 
    private float movementScaleDecrease;
    private bool canMove;
    private bool canClimb;
    private bool onSlope;

    private float horAccRate;
    private float horDecRate;

    private float verAccRate;
    private float verDecRate;

    //Debug
    private Vector3 gizmoBox = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        playerInputSystem = new PlayerControls();

        rb = GetComponent<Rigidbody2D>();

        horizontalMovementInput = 0.0f;

        horAccRate = (50 * speed) / speed;
        horDecRate = (50 * speed) / speed;

        verAccRate = (50 * verticalSpeed) / verticalSpeed;
        verDecRate = (50 * verticalSpeed) / verticalSpeed;

        canMove = true;
        canClimb = false;

        EnableInput();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Vertical
        if (canClimb)
        {
            float verticalForce = verticalMovementInput * verticalSpeed * Time.fixedDeltaTime;
            if(verticalForce != 0)
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0.0f);

                rb.position = new Vector2(rb.position.x, rb.position.y + verticalForce);
            }
        }

        //Horizontal
        if (horizontalMovementInput > 0.0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMovementInput < 0.0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        float targetSpeed = horizontalMovementInput * speed;

        float accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? horAccRate : horDecRate;

        float speedDifference = targetSpeed - rb.velocity.x;

        float horizontalForce = speedDifference * accelRate;

        CheckFire(horizontalForce);

        if (!canMove)
        {
            Debug.Log("Can't move");

            horizontalForce = 0.0f;
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if (onSlope)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        }

        rb.AddForce(horizontalForce * Vector2.right, ForceMode2D.Force);

    }

    private void CheckFire(float movement)
    {
        if (movement != 0.0f)
        {
            Vector3Int currentTile = new Vector3Int(Mathf.FloorToInt(frontStep.position.x), Mathf.FloorToInt(frontStep.position.y - 0.1f), 0);

            gizmoBox = currentTile; //Gizmo Debug

            if(currentTile != lastTilePosition)
            {
                lastTilePosition = currentTile;

                if (groundMap.HasTile(currentTile))
                {
                    if (ashMap.GetTile(currentTile) != flameTile)
                    {

                        if (ReduceSize())
                        {
                            ashMap.SetTile(currentTile, flameTile);
                        }
                        return;
                    }

                    canMove = true;
                }
            }
        }
    }

    private bool ReduceSize()
    {
        Vector3 newSize = new Vector3 (transform.localScale.x > 0.0f ? transform.localScale.x - movementScaleDecrease : transform.localScale.x + movementScaleDecrease, 
                                       transform.localScale.y > 0.0f ? transform.localScale.y - movementScaleDecrease : transform.localScale.y + movementScaleDecrease, 
                                       transform.localScale.z);


        if (Mathf.Abs(newSize.x) >= minimumSize)
        {
            transform.localScale = newSize;
            transform.position = new Vector3(transform.position.x, transform.position.y - movementScaleDecrease / 2, transform.position.z);
            return true;
        }

        canMove = false;
        return false;
    }

    public void EnlargeSize(float sizeIncrease)
    {
        Vector3 newSize = new Vector3(transform.localScale.x > 0.0f ? transform.localScale.x + sizeIncrease : transform.localScale.x - sizeIncrease,
                                      transform.localScale.y > 0.0f ? transform.localScale.y + sizeIncrease : transform.localScale.y - sizeIncrease,
                                      transform.localScale.z);

        transform.localScale = newSize;
    }

    #region Input
    private void EnableInput()
    {
        playerInputSystem.Enable();
        playerInputSystem.PlayerMap.HorizontalMovement.performed += OnHorizontalMovementPerformed;
        playerInputSystem.PlayerMap.HorizontalMovement.canceled += OnHorizontalMovementCancelled;
        playerInputSystem.PlayerMap.VerticalMovement.performed += OnVerticalMovementPerformed;
        playerInputSystem.PlayerMap.VerticalMovement.canceled += OnVerticalMovementCancelled;
        playerInputSystem.PlayerMap.Reset.performed += OnResetPerformed;

    }

    private void DisableInput()
    {
        playerInputSystem.Disable();
        playerInputSystem.PlayerMap.HorizontalMovement.performed -= OnHorizontalMovementPerformed;
        playerInputSystem.PlayerMap.HorizontalMovement.canceled -= OnHorizontalMovementCancelled;
        playerInputSystem.PlayerMap.VerticalMovement.performed -= OnVerticalMovementPerformed;
        playerInputSystem.PlayerMap.VerticalMovement.canceled -= OnVerticalMovementCancelled;
        playerInputSystem.PlayerMap.Reset.performed -= OnResetPerformed;
    }

    private void OnHorizontalMovementPerformed(InputAction.CallbackContext direction)
    {
        horizontalMovementInput = direction.ReadValue<float>();
    }

    private void OnHorizontalMovementCancelled(InputAction.CallbackContext direction) 
    {
        horizontalMovementInput = 0.0f;
    }
    private void OnVerticalMovementPerformed(InputAction.CallbackContext direction)
    {
        verticalMovementInput = direction.ReadValue<float>();
    }

    private void OnVerticalMovementCancelled(InputAction.CallbackContext direction)
    {
        verticalMovementInput = 0.0f;
    }

    private void OnResetPerformed(InputAction.CallbackContext callback)
    {
        Debug.Log("Reset");
    }

    #endregion

    #region Collisions

    private void OnTriggerStay2D(Collider2D collision)
    {
        canClimb = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canClimb = false;
        rb.gravityScale = 1.0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            onSlope = true;
            rb.gravityScale = 0.0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            onSlope = false;
            rb.gravityScale = 1.0f;
        }
    }

    #endregion

    #region Gizmos

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(new Vector3(gizmoBox.x + 0.5f, gizmoBox.y + 0.5f, 0.0f), Vector3.one);
    }

    #endregion
}
