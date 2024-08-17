
using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoading : MonoBehaviour
{
    public GameObject loadingScreen;
    public GameObject menuScreen;
    public Slider slider;
    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsync(name));
        
    }
    
    IEnumerator LoadAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        loadingScreen.SetActive(true);
        menuScreen.SetActive(false);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;

            yield return null;
        }
    }
}
