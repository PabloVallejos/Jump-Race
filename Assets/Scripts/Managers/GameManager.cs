using Cinemachine;
using System.Collections;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private CinemachineVirtualCamera playerCamera;

    [SerializeField]
    private Transform spawnPoint;

    public GameObject player;

    private bool paused = false;
    private bool levelFinished = false;

    private void Start()
    {
        StartCoroutine(InitOnLoadingComplete());
    }

    IEnumerator InitOnLoadingComplete()
    {
        // If the loading scene is still active,
        // all instantiated objects will go to the loading scene
        while (!SceneLoader.Instance.LoadComplete())
        {
            yield return null;
        }
        Init();
    }

    private void Init()
    {
        player = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        playerCamera.LookAt = player.transform;
        playerCamera.Follow = player.transform;
    }

    public void FinishReached()
    {
        levelFinished = true;
        Time.timeScale = 0;
        GUIManager.Instance.ShowFinishScreen();
    }

    void Update()
    {
        if (!levelFinished && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        paused = !paused;
        Time.timeScale = paused ? 0 : 1;
        GUIManager.Instance.ShowPauseScreen(paused);
    }
}
