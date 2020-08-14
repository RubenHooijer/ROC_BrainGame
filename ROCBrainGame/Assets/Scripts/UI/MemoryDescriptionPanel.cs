using UnityEngine;
using UnityEngine.UI;

public class MemoryDescriptionPanel : UIPanel
{
    [Header("References: ")]
    [SerializeField] private Image conditionIcon;

    private Condition currentCondition;

    public void AssignCondition(Condition condition)
    {
        currentCondition = condition;
        conditionIcon.sprite = condition.icon;
        condition.Spawn3dCharacter(Vector3.zero);

        Open();
    }

    public override void Close()
    {
        base.Close();
        currentCondition?.Discard();
    }
}
