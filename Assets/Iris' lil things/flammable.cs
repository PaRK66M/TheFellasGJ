using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class flammable : MonoBehaviour
{
    [SerializeField]
    private bool isOnFire = false;
    private GameObject PlayerObj;
    private GameObject TrackerObj;


    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");
        TrackerObj = GameObject.Find("Tracker");

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Collision w player");
            if (!isOnFire)
            {
                if (PlayerObj.transform.localScale.y >= transform.localScale.y)
                {
                    isOnFire = true;
                    Debug.Log("is on fire true");
                    int objectLayer = LayerMask.NameToLayer("OnFire");
                    gameObject.layer = objectLayer;
                    TrackerObj.GetComponent<TrackerScript>().CountUp();
                    Debug.Log("Im on FIREEE!");

                    collision.gameObject.GetComponent<PlayerMovement>().EnlargeSize();
                }
            }
        }
    }
    public void ResetObj()
    {
        isOnFire = false;
        int objectLayer = LayerMask.NameToLayer("NotOnFire");
        gameObject.layer = objectLayer;
    }
}
