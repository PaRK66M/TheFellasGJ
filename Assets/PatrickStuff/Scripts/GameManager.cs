using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private flammable[] flammableObjects;
    private int flammableIndex;
    private int flammableCount;
    private BurnableRopes[] ropeObjects;
    private int ropeIndex;
    private int ropeCount;
    private BurnableSlopes[] slopeObjects;
    private int slopeIndex;
    private int slopeCount;
    private FrostPotion[] frostObjects;
    private int frostIndex;
    private int frostCount;

    // Start is called before the first frame update
    void Start()
    {
        flammableIndex = -1;
        flammableCount = 0;

        ropeIndex = -1;
        ropeCount = 0;

        slopeIndex = -1;
        slopeCount = 0;

        frostIndex = -1;
        frostCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Found()
    {
        Debug.Log("Found");
    }

    public void AddFlammableObject(flammable obj)
    {
        flammableIndex++;
        if(flammableIndex >= flammableCount)
        {
            flammableCount++;
            flammable[] newArray = new flammable[flammableCount];
            for(int i = 0; i < flammableCount - 1; i++)
            {
                newArray[i] = flammableObjects[i];
            }
            flammableObjects = newArray;
        }
        flammableObjects[flammableIndex] = obj;
    }

    public void AddRopeObject(BurnableRopes obj)
    {
        ropeIndex++;
        if (ropeIndex >= ropeCount)
        {
            ropeCount++;
            BurnableRopes[] newArray = new BurnableRopes[ropeCount];
            for (int i = 0; i < ropeCount - 1; i++)
            {
                newArray[i] = ropeObjects[i];
            }
            ropeObjects = newArray;
        }
        ropeObjects[ropeIndex] = obj;
    }

    public void AddSlopeObject(BurnableSlopes obj)
    {
        slopeIndex++;
        if (slopeIndex >= slopeCount)
        {
            slopeCount++;
            BurnableSlopes[] newArray = new BurnableSlopes[slopeCount];
            for (int i = 0; i < slopeCount - 1; i++)
            {
                newArray[i] = slopeObjects[i];
            }
            slopeObjects = newArray;
        }
        slopeObjects[slopeIndex] = obj;
    }

    public void AddFrostObject(FrostPotion obj)
    {
        frostIndex++;
        if (frostIndex >= frostCount)
        {
            frostCount++;
            FrostPotion[] newArray = new FrostPotion[frostCount];
            for (int i = 0; i < frostCount - 1; i++)
            {
                newArray[i] = frostObjects[i];
            }
            frostObjects = newArray;
        }
        frostObjects[frostIndex] = obj;
    }

    public void ResetLevel()
    {

        for(int i = 0; i <= flammableIndex; i++)
        {
            flammableObjects[i].ResetObj();
        }
        flammableIndex = -1;

        for (int i = 0; i <= ropeIndex; i++)
        {
            ropeObjects[i].ResetRope();
        }
        ropeIndex = -1;

        for (int i = 0; i <= slopeIndex; i++)
        {
            slopeObjects[i].ResetObj();
        }
        slopeIndex = -1;

        for (int i = 0; i <= frostIndex; i++)
        {
            frostObjects[i].ResetPotion();
        }
        frostIndex = -1;

    }
}
