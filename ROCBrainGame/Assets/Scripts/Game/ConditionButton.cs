using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConditionButton : MonoBehaviour
{
    [Header("Settings: ")]
    public int currentNumber = -1;

    [Header("References: ")]
    public Button button;
    public Image buttonBackground;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI numberText;

    public Condition Condition 
    { 
        get => condition; 
        set 
        { 
            condition = value;
            iconImage.sprite = value.icon; 
        } 
    }
    private Condition condition;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    public void SetNumber(int number)
    {
        currentNumber = number;
        numberText.SetText(number.ToString());
        numberText.gameObject.SetActive(true);
    }

    public bool IsCorrect()
    {
        return (currentNumber == condition.controlNumber);
    }
}