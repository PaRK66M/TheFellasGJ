using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class TrackerScript : MonoBehaviour
{
    public int onFireObj = 0;
    public int totalFlammableObj = 0;

    public GameObject[] flammableObj;

    public Slider sliderFlame;

    // Start is called before the first frame update
    void Start()
    {
        totalFlammableObj = flammableObj.Length;
        sliderFlame.maxValue = totalFlammableObj;
        sliderFlame.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CountUp()
    {
        onFireObj++;
        sliderFlame.value = onFireObj;
        if (totalFlammableObj <= onFireObj)
        {
            Debug.Log("Level Complete!");
            //ResetLayers();
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
