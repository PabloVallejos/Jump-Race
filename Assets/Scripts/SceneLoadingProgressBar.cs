using UnityEngine;
using UnityEngine.UI;

public class SceneLoadingProgressBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    [SerializeField]
    private float loadingSmoothness = 2f;

    private float previousValue = 0;
    private float targetValue = 0;
    private float currentValue = 0;
    private float time = 0;

    private void Start()
    {
        SceneLoader.Instance.OnProgressChanged += ProgressChanged;
    }

    private void OnDestroy()
    {
        SceneLoader.Instance.OnProgressChanged -= ProgressChanged;
    }

    private void ProgressChanged(float progress)
    {
        targetValue = progress;
        time = 0;
    }

    private void Update()
    {
        //Make a soft progress on the loading bar
        time += Time.deltaTime * (1/loadingSmoothness);

        previousValue = currentValue;
        currentValue = Mathf.Lerp(previousValue, targetValue, time);

        slider.value = currentValue;
    }
}
