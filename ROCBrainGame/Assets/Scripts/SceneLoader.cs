using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance => instance;
    private static SceneLoader instance;

    private void Awake()
    {
        if(Instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this);
        }
    }

    public static void LoadScene(Scenes scene, Transitions transition = Transitions.BlueBrain)
    {
        TransitionManager.DoTransition(transition, () => instance.StartCoroutine(ieLoadScene((int)scene)), false);
    }

    private static IEnumerator ieLoadScene(int buildindex)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(buildindex);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
                TransitionManager.CloseTransition();
            }

            yield return null;
        }
    }
}

public enum Scenes
{
    StartMenu = 0,
    KennisSpel = 1,
    MemorySpel = 2
}
