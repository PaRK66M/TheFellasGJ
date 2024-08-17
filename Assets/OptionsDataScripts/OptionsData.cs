using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsData : MonoBehaviour
{
    // Start is called before the first frame update

    public float volume;

    void Start()
    {
        GetAllOptionsData();
    }

    // Update is called once per frame
    void GetAllOptionsData()
    {
        volume = PlayerPrefs.GetFloat("volume");
    }

    void SetVolume ()
    {

    }
}
