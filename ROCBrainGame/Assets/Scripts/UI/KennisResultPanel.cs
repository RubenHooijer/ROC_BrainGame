using UnityEngine;
using TMPro;

public class KennisResultPanel : UIPanel, IChangeableHeader, IShowResults
{
    private const string LIST_ITEM_SUFFIX = "\n\n";

    [Header("References: ")]
    [SerializeField] private TextMeshProUGUI listOfWrongAnswersText;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void ChangeHeader(string headerText)
    {
        messageText.text = headerText; 
    }

    public void ShowScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowWrongAnswers(params string[] wrongAnswers)
    {
        string text = default;
        for (int i = 0; i < wrongAnswers.Length; i++)
        {
            text += wrongAnswers[i] + LIST_ITEM_SUFFIX;
        }
        listOfWrongAnswersText.text = text;
    }
}
