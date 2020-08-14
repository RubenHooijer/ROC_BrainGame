using TMPro;
using UnityEngine;

public class KennisRightTransition : UIPanel, IChangeableHeader
{
    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI headerText;

    public void ChangeHeader(string headerText)
    {
        throw new System.NotImplementedException();
    }
}
