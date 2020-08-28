using UnityEngine;
using TMPro;

public class KennisWrongTransition : UIPanel
{
    private const string RIGHT_ANSWER_PREFIX = "Het goede antwoord was \n<size=120><color=#3DCB29><b>";
    private const string RIGHT_ANSWER_MIDDLE = "</b></color></size>\nJij koos \n<size=120><color=#000><b>";
    private const string RIGHT_ANSWER_SUFFIX = "</b></size>";

    [Header("References: ")]
    [SerializeField] private KennisFaults faultsMade;
    [SerializeField] private TextMeshProUGUI rightAnswerText;

    public void ChangeHeader(string rightAnswer, string youGuessed)
    {
        rightAnswerText.text = RIGHT_ANSWER_PREFIX + rightAnswer + RIGHT_ANSWER_MIDDLE + youGuessed + RIGHT_ANSWER_SUFFIX;
    }

    public override void Open()
    {
        base.Open();
        KennisSpel.UpdateFaultsMade?.Invoke();
    }
}
