using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FrostEffect : MonoBehaviour
{
    public bool enabledState = false;
    public bool finishedReset = false;

    [SerializeField]
    private Transform leftmostTile;
    [SerializeField]
    private Transform rightmostTile;
    [SerializeField] private flammable[] flammableObjects;
    [SerializeField] private BurnableRopes[] ropeObjects;
    [SerializeField] private BurnableSlopes[] slopeObjects;

    private Tilemap ashGrid;
    private FireManager fireManager;

    private BoxCollider2D collider2d;

    public void Initialise()
    {
        collider2d = GetComponent<BoxCollider2D>();

        ashGrid = GameObject.FindGameObjectWithTag("AshMap").GetComponent<Tilemap>();
        fireManager = GameObject.FindGameObjectWithTag("BurnManager").GetComponent<FireManager>();

        gameObject.SetActive(false);
    }

    public void Unfreeze()
    {
        enabledState = false;
        finishedReset = true; //Change if adding unfreeze

        foreach (flammable flame in flammableObjects)
        {
            flame.Unfreeze();
        }
        foreach (BurnableRopes rope in ropeObjects)
        {
            rope.Unfreeze();
        }
        foreach (BurnableSlopes slopes in slopeObjects)
        {
            slopes.Unfreeze();
        }
    }

    public void Freeze()
    {
        enabledState = true;

        int leftmostTilePosition = Mathf.FloorToInt(leftmostTile.position.x);
        int rightmostTilePosition = Mathf.CeilToInt(rightmostTile.position.x);

        int tileYValue = Mathf.FloorToInt(leftmostTile.position.y);

        for (int i = leftmostTilePosition; i < rightmostTilePosition; i++)
        {
            Vector3Int tilePosition = new Vector3Int(i, tileYValue, 0);
            ashGrid.SetTile(tilePosition, null);
        }

        fireManager.FreezeFires(leftmostTilePosition, rightmostTilePosition);

        foreach(flammable flame in flammableObjects)
        {
            flame.Freeze();
        }
        foreach (BurnableRopes rope in ropeObjects)
        {
            rope.Freeze();
        }
        foreach (BurnableSlopes slopes in slopeObjects)
        {
            slopes.Freeze();
        }
    }

    private void Update()
    {
        if (!enabled && finishedReset)
        {
            gameObject.SetActive(false);
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Debug.Log(collision.name);

    //    if (collision.gameObject.GetComponent<flammable>() != null)
    //    {
    //        if (enabledState)
    //        {
    //            collision.gameObject.GetComponent<flammable>().Freeze();
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<flammable>().Unfreeze();
    //        }
            
    //    }
    //    else if (collision.gameObject.GetComponent<BurnableRopes>() != null)
    //    {
    //        if (enabledState)
    //        {
    //            collision.gameObject.GetComponent<BurnableRopes>().Freeze();
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<BurnableRopes>().Unfreeze();
    //        }
            
    //    }
    //    else if (collision.gameObject.GetComponent<BurnableSlopes>() != null)
    //    {
    //        if (enabledState)
    //        {
    //            collision.gameObject.GetComponent<BurnableSlopes>().Freeze();
    //        }
    //        else
    //        {
    //            collision.gameObject.GetComponent<BurnableSlopes>().Unfreeze();
    //        }
            
    //    }
    //    else if(collision.gameObject.layer == 14)
    //    {
    //        collision.gameObject.SetActive(false);
    //    }
    //}
}
