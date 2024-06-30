using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region Singleton
    [SerializeField]
    private bool dontDestroyOnLoad = false;

    private static SceneLoader _instance;

    public static SceneLoader Instance => _instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
    #endregion

    [SerializeField]
    private string loadingSceneName = "Loading";

    [SerializeField]
    private float sceneActivationDelay = 0.5f;

    public float Progress { get; private set; }

    public event Action<float> OnProgressChanged;


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadYourAsyncScene(sceneName));
    }

    private IEnumerator LoadYourAsyncScene(string sceneName)
    {
        SetProgress(0);

        //Show loading screen
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadingSceneName);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        //Load scene
        asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= 0.9f)
            {
                SetProgress(1);

                //Wait a bit when the scene is loaded to avoid a "flash" loading screen
                yield return new WaitForSeconds(sceneActivationDelay);
                asyncLoad.allowSceneActivation = true;
            }
            else
            {
                SetProgress(asyncLoad.progress);
                yield return null;
            }

            SceneManager.UnloadSceneAsync(loadingSceneName);
        }
    }

    private void SetProgress(float progress)
    {
        Progress = progress;
        OnProgressChanged?.Invoke(progress);
    }
}
