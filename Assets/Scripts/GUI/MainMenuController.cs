using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject exitButton;

    private void Start()
    {
        if (Application.isEditor
            || Application.platform == RuntimePlatform.WebGLPlayer
            || Application.isMobilePlatform)
        {
            exitButton.SetActive(false);
        }
    }
    public void LoadLevel()
    {
        //SceneLoader.Instance.LoadScene("GUITest");
        SceneLoader.Instance.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
