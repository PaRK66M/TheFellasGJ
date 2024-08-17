
using System.Collections;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoading : MonoBehaviour
{
    //object references
    public Slider slider;
    public TMP_Text progressText;

    //start coroutine
    public void LoadLevel(string name)
    {
        StartCoroutine(LoadAsync(name));
    }
    
    //load scene asynchronously and update UI elements with values based on progress
    //of this asyn function
    IEnumerator LoadAsync(string name)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            progressText.text = progress*100f + "%";

            yield return null;
        }
    }
}
