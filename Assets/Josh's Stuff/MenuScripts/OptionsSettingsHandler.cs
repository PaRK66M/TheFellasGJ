using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionsSettingsHandler : MonoBehaviour
{
    //if no volume initialise default value
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 30f);
        }
    }

    //update volume when slider changes
    public void OnVolumeChanged(Slider slider)
    {
        PlayerPrefs.SetFloat("volume", slider.value);
    }
}
