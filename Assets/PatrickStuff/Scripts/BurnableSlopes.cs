using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSlopes : MonoBehaviour
{
    private bool isOnFire = false;
    [SerializeField]
    private float fuelIncrease;

    private Transform startPosition;

    private GameManager gameManager;
    private FireManager fireManager;
    private SpriteRenderer spriteRenderer;

    private HingeJoint2D hingeJoint;
    public bool hasHingeJoint;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        fireManager = GameObject.FindWithTag("BurnManager").GetComponent<FireManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        startPosition = transform;

        if (hasHingeJoint)
            hingeJoint = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Player")
        {
            if (!isOnFire)
            {
                isOnFire = true;
                SetOnFire(collision.gameObject.GetComponent<PlayerMovement>());
            }
        }
    }

    private void SetOnFire(PlayerMovement player)
    {
        isOnFire = true;
        //Debug.Log("is on fire true");
        int objectLayer = LayerMask.NameToLayer("OnFire");
        gameObject.layer = objectLayer;
        //Debug.Log("Im on FIREEE!");
        player.EnlargeSize(fuelIncrease);
        fireManager.SpawnFire(transform.position, Vector3.one);
        spriteRenderer.color = Color.black;
        gameManager.AddSlopeObject(this);

    }

    public void ResetObj()
    {
        if (hasHingeJoint)
            hingeJoint.enabled = false;
        isOnFire = false;
        int objectLayer = LayerMask.NameToLayer("NotOnFire");
        transform.position = startPosition.position;
        transform.rotation = startPosition.rotation;
        gameObject.layer = objectLayer;

        spriteRenderer.color = Color.white;
        if (hasHingeJoint)
            hingeJoint.enabled = true;
    }

    public void Freeze()
    {
        isOnFire = true;
        int objectLayer = LayerMask.NameToLayer("NotOnFire");
        gameObject.layer = objectLayer;
        spriteRenderer.color = Color.white;
    }

    public void Unfreeze()
    {
        isOnFire = false;
    }
}
