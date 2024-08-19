using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;

public class TrackerScript : MonoBehaviour
{
    //public int onFireObj = 0;
    //public int totalFlammableObj = 0;

    //public GameObject[] flammableObj;
    [SerializeField]
    private GameObject PlayerObj;

    public Slider sliderFlame;

    private float maxSlider;
    //private float currentSlider;

    // Start is called before the first frame update
    void Start()
    {
        //totalFlammableObj = flammableObj.Length;

        maxSlider = PlayerObj.GetComponent<PlayerMovement>().movementScaleDecrease * 10;
        sliderFlame.maxValue = maxSlider;
        sliderFlame.value = maxSlider;
    }

    // Update is called once per frame
    void Update()
    {
        //if(PlayerObj.transform.localScale.y - PlayerObj.GetComponent<PlayerMovement>().minimumSize < maxSlider)
        //{
        //    sliderFlame.value = PlayerObj.transform.localScale.y - PlayerObj.GetComponent<PlayerMovement>().minimumSize;
        //}
        //else
        //{
        //    sliderFlame.value = maxSlider;
        //}

        if (PlayerObj.transform.localScale.y - PlayerObj.GetComponent<PlayerMovement>().minimumSize >= maxSlider)
        {
            sliderFlame.value = maxSlider;
        }
        else
        {
            sliderFlame.value = PlayerObj.transform.localScale.y - PlayerObj.GetComponent<PlayerMovement>().minimumSize;
        }
    }

    //public void CountUp()
    //{
    //    onFireObj++;
    //    sliderFlame.value = onFireObj;
    //    if (totalFlammableObj <= onFireObj)
    //    {
    //        Debug.Log("Level Complete!");
    //        //ResetLayers();
    //    }
    //}

    //void ResetLayers()
    //{
    //    for (int i=0; i< flammableObj.Length; ++i)
    //    {
    //        flammableObj[i].GetComponent<flammable>().ResetObj();
    //    }
    //    Debug.Log("Objects Reset");
    //}
}
