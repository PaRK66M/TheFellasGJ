using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonBehaviours : MonoBehaviour
{
    [SerializeField] string gameSceneName;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject loadingScreen;
    public Slider slider;
    public TMP_Text progressText;

    public void ToOptionsMenu()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ToMainMenu()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsync(name));
        
    }
    
    IEnumerator LoadAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        loadingScreen.SetActive(true);
        mainMenu.SetActive(false);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            progressText.text = progress*100f + "%";

            yield return null;
        }
    }
}
