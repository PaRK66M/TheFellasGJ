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


    // Start is called before the first frame update
    void Start()
    {
        PlayerObj = GameObject.Find("Player");

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
                if (PlayerObj.transform.localScale.y >= transform.localScale.y)
                {
                    isOnFire = true;
                    int objectLayer = LayerMask.NameToLayer("OnFire");
                    gameObject.layer = objectLayer;
                }
            }
        }
    }
}
