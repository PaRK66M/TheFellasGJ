using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonBehaviours : MonoBehaviour
{
    //Initialise references to objects scene objects
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loadingScreen;

    //options menu activation (can only occur from menu scene so that is the only one we need to toggle)
    public void ToOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    //main menu activation (can only occur from options scene so we only toggle options)
    public void ToMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    //load level using loading screen scripting
    public void LoadLevel(string name)
    {
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        loadingScreen.GetComponent<LevelLoading>().LoadLevel(name);
    }
}
