using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableSlopes : MonoBehaviour
{
    private bool isOnFire = false;
    [SerializeField]
    private float fuelIncrease;

    private Vector3 startPosition;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        startPosition = transform.position;
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

        gameManager.AddSlopeObject(this);
    }

    public void ResetObj()
    {
        isOnFire = false;
        int objectLayer = LayerMask.NameToLayer("NotOnFire");
        transform.position = startPosition;
        gameObject.layer = objectLayer;
    }
}
