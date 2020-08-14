using UnityEngine;
using TMPro;

public class KennisResultPanel : UIPanel, IChangeableHeader, IShowResults
{
    private const string SCORE_TEXT_PREFIX = "Score: ";
    private const string LIST_OF_WRONG_ANSWERS_PREFIX = "Je hebt de volgende termen verkeerd geraden: \n";
    private const string LIST_ITEM_PREFIX = " • ";
    private const string LIST_ITEM_SUFFIX = "\n";

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
        scoreText.text = SCORE_TEXT_PREFIX + score.ToString();
    }

    public void ShowWrongAnswers(params string[] wrongAnswers)
    {
        string text = LIST_OF_WRONG_ANSWERS_PREFIX;
        for (int i = 0; i < wrongAnswers.Length; i++)
        {
            text += LIST_ITEM_PREFIX + wrongAnswers[i] + LIST_ITEM_SUFFIX;
        }
        listOfWrongAnswersText.text = text;
    }
}
