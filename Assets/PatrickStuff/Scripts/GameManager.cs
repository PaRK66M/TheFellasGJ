using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<flammable> flammableObjects;
    private List<BurnableRopes> ropeObjects;
    private List<BurnableSlopes> slopeObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddFlammableObject(flammable obj)
    {
        flammableObjects.Add(obj);
    }

    public void AddRopeObject(BurnableRopes obj)
    {
        ropeObjects.Add(obj);
    }

    public void AddSlopeObject(BurnableSlopes obj)
    {
        slopeObjects.Add(obj);
    }

    public void ResetLevel()
    {
        foreach(flammable flame in flammableObjects)
        {
            flame.ResetObj();
        }
        flammableObjects.Clear();

    }
}
