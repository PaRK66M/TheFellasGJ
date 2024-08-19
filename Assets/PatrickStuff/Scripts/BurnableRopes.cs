using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableRopes : MonoBehaviour
{
    private bool onFire;
    [SerializeField]
    private bool hasJoint;
    [SerializeField]
    private float fuelIncrease;

    private HingeJoint2D joint;

    private SpriteRenderer spriteRenderer;
    private FireManager fireManager;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fireManager = GameObject.FindWithTag("BurnManager").GetComponent<FireManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        onFire = false;
        if (hasJoint)
        {
            joint = GetComponent<HingeJoint2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (!onFire)
            {
                onFire = true;
                gameObject.layer = 8;
                SetFireImage();
                collision.gameObject.GetComponent<PlayerMovement>().EnlargeSize(fuelIncrease);
                if (hasJoint)
                {
                    joint.enabled = false;
                }

                gameManager.AddRopeObject(this);
            }
            
        }
    }

    private void SetFireImage()
    {
        spriteRenderer.color = Color.gray;
        fireManager.SpawnFire(transform.position, Vector3.one);
    }

    public void RemoveFireImage()
    {
        spriteRenderer.color = Color.white;
    }

    public void ResetRope()
    {
        onFire = false;
        gameObject.layer = 7;
        RemoveFireImage();
        if (hasJoint)
        {
            joint.enabled = true;
        }
    }
}
