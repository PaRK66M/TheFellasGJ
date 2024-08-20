using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    [SerializeField]
    private GameObject PauseMenuUI;
    [SerializeField]
    private GameObject OptionMenuUI;
    //[SerializeField]
    //private GameObject VictoryScreenUI;
    //[SerializeField]
    //private GameObject TrackerObj;

    [SerializeField]
    private GameObject GameSceneStuff;

    [SerializeField]
    private GameObject LoadingScreen;

    void Start()
    {
        Resume();
    }
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
        //if (TrackerObj.GetComponent<TrackerScript>().totalFlammableObj - TrackerObj.GetComponent<TrackerScript>().onFireObj <= 0)
        //{
        //    Victory();
        //}
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

    //void Victory()
    //{
    //    VictoryScreenUI.SetActive(true);
    //}
    //load menu

   
    
    public void LoadMenu()
    {
        LoadingScreen.SetActive(true);
        //SceneManager.LoadScene("MenuScene");
        LoadingScreen.GetComponent<LevelLoading>().LoadLevel("MenuScene");
        GameSceneStuff.SetActive(false);
    }

}
