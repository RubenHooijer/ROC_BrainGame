using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MemoryDescriptionPanel : UIPanel
{
    [Header("References: ")]
    [SerializeField] private Image conditionIcon;
    [SerializeField] private TextMeshProUGUI descriptionText;

    private Condition _currentCondition;

    public void AssignCondition(Condition condition)
    {
        _currentCondition = condition;
        conditionIcon.sprite = condition.icon;
        RenderTextureScene.ShowCondition(condition);
        descriptionText.SetText(condition.description);

        Open();
    }

    public override void Close()
    {
        base.Close();
    }
}
