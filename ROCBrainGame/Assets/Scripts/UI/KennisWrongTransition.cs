using UnityEngine;
using TMPro;

public class KennisWrongTransition : UIPanel, IChangeableHeader
{
    private const string RIGHT_ANSWER_PREFIX = "The right answer was ";

    [Header("References: ")]
    [SerializeField] private KennisFaults faultsMade;
    [SerializeField] private TextMeshProUGUI rightAnswerText;

    public void ChangeHeader(string rightAnswer)
    {
        rightAnswerText.text = RIGHT_ANSWER_PREFIX + rightAnswer;
    }

    public override void Open()
    {
        base.Open();
        KennisSpel.UpdateFaultsMade?.Invoke();
    }
}
