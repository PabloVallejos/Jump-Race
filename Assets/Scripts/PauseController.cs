using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseScreen;

    private bool paused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        pauseScreen.SetActive(paused);
        Time.timeScale = paused ? 0 : 1;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        string sceneName = SceneManager.GetActiveScene().path;
        SceneLoader.Instance.LoadScene(sceneName);
    }

    public void ExitLevel()
    {
        Time.timeScale = 1;
        SceneLoader.Instance.LoadScene("MainMenu");
    }
}
