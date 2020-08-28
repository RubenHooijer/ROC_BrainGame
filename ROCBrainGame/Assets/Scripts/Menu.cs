using UnityEngine;

public class Menu : MonoBehaviour
{
    public void GoToKennisSpel()
    {
        SceneLoader.LoadScene(Scenes.KennisSpel, Transitions.PinkBrain);
    }

    public void GoToMemorySpel()
    {
        SceneLoader.LoadScene(Scenes.MemorySpel, Transitions.BlueBrain);
    }
}
