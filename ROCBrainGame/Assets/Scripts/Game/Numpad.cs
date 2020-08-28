using System;
using UnityEngine;
using UnityEngine.UI;

public class Numpad : MonoBehaviour
{
    public static Action<int> OnEnterNumber;

    [Header("Settings: ")]
    [SerializeField] private Color selectedButtonColor;

    [Header("References: ")]
    [SerializeField] private Image[] numberButtonList;
    [SerializeField] private Button enterButton;
    private int selectedNumber = 1;

    private void Awake()
    {
        OnEnterNumber += DeselectButton;
    }

    private void OnDestroy()
    {
        OnEnterNumber -= DeselectButton;
    }

    public void SelectButton(int number)
    {
        if (number == 0) return;
        if (selectedNumber != 0) numberButtonList[selectedNumber].color = Color.white;

        selectedNumber = number;
        numberButtonList[selectedNumber].color = selectedButtonColor;
    }

    private void DeselectButton(int x)
    {
        if (x != 0) numberButtonList[x].color = Color.white;
        selectedNumber = 1;
    }

    public void EnterNumber()
    {
        enterButton.interactable = false;
        OnEnterNumber?.Invoke(selectedNumber);
        enterButton.interactable = true;
    }
}
