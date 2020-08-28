using Extensions.Generics.Singleton;

public class UIManager : GenericSingleton<UIManager, IUIManager>, IUIManager
{
    public IUIPanel NextPanel { get => nextPanel; set => nextPanel = value; }
    private IUIPanel nextPanel;

    private IUIPanel currentPanel;

    public void OpenPanel(IUIPanel panel)
    {
        NextPanel = panel;
        ShowNextPanel();
    }

    public void ShowNextPanel()
    {
        currentPanel?.Close();
        nextPanel?.Open();

        currentPanel = nextPanel;
    }
}

public interface IUIManager
{
    IUIPanel NextPanel { get; set; }
    void OpenPanel(IUIPanel panel);
}
