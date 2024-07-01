using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    [SerializeField]
    private bool dontDestroyOnLoad = false;

    private static T _instance;

    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = this as T;
            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
