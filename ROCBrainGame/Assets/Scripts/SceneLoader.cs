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

    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}

public enum Scenes
{
    StartMenu = 0,
    KennisSpel = 1,
    MemorySpel = 2
}
