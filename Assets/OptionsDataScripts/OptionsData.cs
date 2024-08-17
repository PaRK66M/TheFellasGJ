using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsData : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float volume;

    void Start()
    {
        GetAllOptionsData();
    }

    // Update is called once per frame
    public void GetAllOptionsData()
    {
        volume = PlayerPrefs.GetFloat("volume");
    }

    public void SetAllOptionsData()
    {
        PlayerPrefs.SetFloat("volume", volume);
    }
}
