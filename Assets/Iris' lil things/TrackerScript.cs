using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class TrackerScript : MonoBehaviour
{
    [SerializeField]
    private int onFireObj = 0;
    private int totalFlammableObj = 0;

    public GameObject[] flammableObj;

    // Start is called before the first frame update
    void Start()
    {
        totalFlammableObj = flammableObj.Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountUp()
    {
        onFireObj++;
        if (totalFlammableObj <= onFireObj)
        {
            Debug.Log("Level Complete!");
            ResetLayers();
        }
    }

    void ResetLayers()
    {
        for (int i=0; i< flammableObj.Length; ++i)
        {
            flammableObj[i].GetComponent<flammable>().ResetObj();
        }
        Debug.Log("Objects Reset");
    }
}
