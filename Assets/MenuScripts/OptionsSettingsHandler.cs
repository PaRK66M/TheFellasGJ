using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSettingsHandler : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetFloat("volume", 30f);
    }
    public void OnVolumeChanged(Slider slider)
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }

    void Update()
    {
        Debug.Log(PlayerPrefs.GetFloat("volume"));
    }
}
