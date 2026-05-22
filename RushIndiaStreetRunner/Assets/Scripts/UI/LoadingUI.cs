using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

namespace RushIndia.UI
{
    /// <summary>
    /// Loading/Splash screen controller.
    /// Shows game logo, progress bar, and loads into MainMenu.
    /// </summary>
    public class LoadingUI : MonoBehaviour
    {
        [Header("UI Elements")]
        [SerializeField] private Slider progressBar;
        [SerializeField] private float minimumLoadTime = 2f; // Minimum splash duration

        [Header("Next Scene")]
        [SerializeField] private string nextScene = "MainMenu";

        private void Start()
        {
            StartCoroutine(LoadNextScene());
        }

        private IEnumerator LoadNextScene()
        {
            float timer = 0f;

            // Start async load
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(nextScene);
            asyncLoad.allowSceneActivation = false;

            while (!asyncLoad.isDone)
            {
                timer += Time.deltaTime;

                // Calculate progress (0 to 0.9 is loading, 0.9 means ready)
                float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);

                // Also factor in minimum load time
                float timeProgress = Mathf.Clamp01(timer / minimumLoadTime);
                float displayProgress = Mathf.Min(progress, timeProgress);

                if (progressBar != null)
                    progressBar.value = displayProgress;

                // Activate scene when both loading is done AND minimum time passed
                if (asyncLoad.progress >= 0.9f && timer >= minimumLoadTime)
                {
                    if (progressBar != null) progressBar.value = 1f;
                    yield return new WaitForSeconds(0.2f); // Brief pause at 100%
                    asyncLoad.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
