using UnityEngine;
using UnityEngine.UI;

public class MemoryInputPanel : UIPanel
{
    [Header("References: ")]
    [SerializeField] private Image _conditionIcon;

    private ConditionButton currentConditionButton;

    public void Show(ConditionButton conditionButton)
    {
        currentConditionButton = conditionButton;
        _conditionIcon.sprite = conditionButton.Condition.icon;
        Numpad.OnEnterNumber += currentConditionButton.SetNumber;
        base.Open();
    }

    public override void Close()
    {
        Numpad.OnEnterNumber -= currentConditionButton.SetNumber;
        base.Close();
    }

    private void OnDestroy()
    {
        Numpad.OnEnterNumber -= currentConditionButton.SetNumber;
    }
}