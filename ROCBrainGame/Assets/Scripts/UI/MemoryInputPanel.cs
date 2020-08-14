public class MemoryInputPanel : UIPanel
{
    private ConditionButton currentConditionButton;

    public void Show(ConditionButton conditionButton)
    {
        base.Open();
        currentConditionButton = conditionButton;
        Numpad.OnEnterNumber += currentConditionButton.SetNumber;
    }

    public override void Close()
    {
        base.Close();
        Numpad.OnEnterNumber -= currentConditionButton.SetNumber;
    }

    private void OnDestroy()
    {
        Numpad.OnEnterNumber -= currentConditionButton.SetNumber;
    }
}