using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnableRopes : MonoBehaviour
{
    private bool onFire;

    // Start is called before the first frame update
    void Start()
    {
        onFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
    }
}
