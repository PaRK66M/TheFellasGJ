using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class flammable : MonoBehaviour
{
    [SerializeField]
    private bool isOnFire = false;
    [SerializeField]
    private bool instantFire = false;
    [SerializeField]
    private GameObject PlayerObj;
    //private GameObject TrackerObj;
    [SerializeField]
    private float fuelIncrease;

    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;
    private FireManager fireManager;


    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        //TrackerObj = GameObject.Find("Tracker");

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        fireManager = GameObject.FindWithTag("BurnManager").GetComponent <FireManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //Debug.Log("Collision w player");
            if (!isOnFire)
            {
                if (instantFire)
                {
                    SetOnFire(collision.gameObject.GetComponent<PlayerMovement>());
                    
                }
                else if (PlayerObj.transform.localScale.y >= transform.localScale.y)
                {
                    SetOnFire(collision.gameObject.GetComponent<PlayerMovement>());
                }
            }
        }
    }

    private void SetOnFire(PlayerMovement player)
    {
        isOnFire = true;
        //Debug.Log("is on fire true");
        int objectLayer = LayerMask.NameToLayer("OnFire");
        gameObject.layer = objectLayer;
        //TrackerObj.GetComponent<TrackerScript>().CountUp();

        //Debug.Log("Im on FIREEE!");
        player.EnlargeSize(fuelIncrease);

        spriteRenderer.color = Color.black;

        gameManager.AddFlammableObject(this);
        fireManager.SpawnFire(transform.position, Vector3.one);
    }

    public void ResetObj()
    {
        isOnFire = false;
        int objectLayer = LayerMask.NameToLayer("NotOnFire");
        gameObject.layer = objectLayer;

        spriteRenderer.color = Color.white;
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
