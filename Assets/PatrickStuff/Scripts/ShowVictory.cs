using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowVictory : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryScren;
    [SerializeField]
    private PlayerMovement player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            victoryScren.SetActive(true);
            player.DisableInput();
        }
    }
}
