using UnityEngine;

public class UIPanel : MonoBehaviour, IUIPanel
{
    [SerializeField]
    private bool _useTransition = false;
    public bool UseTransition => _useTransition;

    [SerializeField]
    private Transitions _transitionType;

    public virtual void Open()
    {
        if (_useTransition)
        {
            TransitionManager.DoTransition(_transitionType, ActivateGameobject);
        } else
        {
            ActivateGameobject();
        }
    }

    public void ActivateGameobject()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateGameobject()
    {
        gameObject.SetActive(false);
    }

    public virtual void Close()
    {
        if (UIManager.Instance.NextPanel.UseTransition)
        {
            TransitionManager.OnPeakTransition += DeactivateGameobject;
        } else
        {
            DeactivateGameobject();
        }
    }
}

public interface IUIPanel
{
    bool UseTransition { get; }
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
