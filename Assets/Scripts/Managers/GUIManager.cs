using UnityEngine;

public class GUIManager : Singleton<GUIManager>
{
    [SerializeField]
    private GameObject pauseScreen;

    [SerializeField]
    private GameObject finishScreen;

    public void ShowPauseScreen(bool show)
    {
        pauseScreen.SetActive(show);
    }

    public void ResumeGame()
    {
        GameManager.Instance.TogglePause();
    }

    public void RestartLevel()
    {
        SceneLoader.Instance.RestartLevel();
    }

    public void ExitLevel()
    {
        SceneLoader.Instance.GoToMainMenu();
    }

    public void ShowFinishScreen()
    {
        finishScreen.SetActive(true);
    }
}
