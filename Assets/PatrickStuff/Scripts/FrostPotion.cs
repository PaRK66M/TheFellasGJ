using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostPotion : MonoBehaviour
{
    private Vector3 startPosition;
    private bool isBroken;

    [SerializeField]
    private FrostEffect frostEffect;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        isBroken = false;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 12)
        {
            if(!isBroken) 
            { 
                gameManager.AddFrostObject(this);
                isBroken = true; 
                BreakAnimation();
                EnableFrost();
            }
        }
    }

    private void BreakAnimation()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void EnableFrost()
    {
        frostEffect.Initialise();
        frostEffect.gameObject.SetActive(true);
        frostEffect.Freeze();
    }

    public void ResetPotion()
    {
        Debug.Log("Resetting");
        frostEffect.Unfreeze();
        frostEffect.gameObject.SetActive(false);

        GetComponent<SpriteRenderer>().enabled = true;

        transform.position = startPosition;
        isBroken = false;
    }
}
