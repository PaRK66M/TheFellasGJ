using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField]
    private GameObject PauseMenuUI;
    [SerializeField]
    private GameObject OptionMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        OptionMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Options()
    {
        PauseMenuUI.SetActive(false);
        OptionMenuUI.SetActive(true);
    }

    public void Back()
    {
        PauseMenuUI.SetActive(true);
        OptionMenuUI.SetActive(false);
    }
    //load menu
    //quit game
}
