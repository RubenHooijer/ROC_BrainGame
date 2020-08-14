using UnityEngine;

public class UIPanel : MonoBehaviour, IUIPanel
{
    public virtual void Open()
    {
        gameObject?.SetActive(true);
    }

    public virtual void Close()
    {
        gameObject?.SetActive(false);
    }
}

public interface IUIPanel
{
    void Open();
    void Close();
}

public interface IChangeableHeader
{
    void ChangeHeader(string headerText);
}

public interface IShowResults
{
    void ShowWrongAnswers(params string[] wrongAnswers);
    void ShowScore(int score);
}
