using UnityEngine;
using UnityEngine.UI;

public class MemoryDescriptionPanel : UIPanel
{
    [Header("References: ")]
    [SerializeField] private Image conditionIcon;

    private Condition _currentCondition;

    public void AssignCondition(Condition condition)
    {
        _currentCondition = condition;
        conditionIcon.sprite = condition.icon;
        RenderTextureScene.ShowCondition(condition);

        Open();
    }

    public override void Close()
    {
        base.Close();
    }
}
