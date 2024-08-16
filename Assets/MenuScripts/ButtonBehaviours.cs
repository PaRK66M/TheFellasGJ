using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviours : MonoBehaviour
{
    [SerializeField] string gameSceneName;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public void LoadGameScene()
    {
        //Debug.Log("clicked");
        SceneManager.LoadScene(gameSceneName);
    }

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
}
