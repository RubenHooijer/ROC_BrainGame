using UnityEngine;

public class Menu : MonoBehaviour
{
    public void GoToKennisSpel()
    {
        SceneLoader.LoadScene(Scenes.KennisSpel);
    }

    public void GoToMemorySpel()
    {
        SceneLoader.LoadScene(Scenes.MemorySpel);
    }
}
