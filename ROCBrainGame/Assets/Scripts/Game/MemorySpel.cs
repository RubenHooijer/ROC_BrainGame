using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Extensions.List;
using System.Collections;

public class MemorySpel : MonoBehaviour
{

    [Header("References: ")]
    [SerializeField] private Condition[] allConditions;

    [Space()]
    [SerializeField] private Slider setupSlider;
    [SerializeField] private ConditionButton conditionButtonPrefab;
    [SerializeField] private Transform buttonGroup;

    [Space()]
    [SerializeField] private MemoryDescriptionPanel memoryDescriptionPanel;
    [SerializeField] private MemoryInputPanel memoryInputPanel;
    [SerializeField] private GameObject checkAnswersButton;


    private int amountOfConditions;
    private List<ConditionButton> spawnedButtons = new List<ConditionButton>();

    public void SetupGame()
    {
        amountOfConditions = (int)setupSlider.value;

        List<int> conditionOrder = new List<int>();

        for (int i = 0; i < allConditions.Length; i++)
        {
            conditionOrder.Add(i);
        }

        conditionOrder.Shuffle();

        for (int i = 0; i < amountOfConditions; i++)
        {
            var obj = Instantiate(conditionButtonPrefab, buttonGroup);
            obj.Condition = allConditions[conditionOrder[i]];
            obj.button.onClick.AddListener(() => memoryDescriptionPanel.AssignCondition(obj.Condition));

            spawnedButtons.Add(obj);
        }

        Debug.Log("Setup complete");
    }

    public void StartGame()
    {
        for (int i = 0; i < spawnedButtons.Count; i++)
        {
            var button = spawnedButtons[i];
            button.button.onClick.RemoveAllListeners();
            button.button.onClick.AddListener(() => memoryInputPanel.Show(button));
        }

        Numpad.OnEnterNumber += OnEnterNumber;
        Debug.Log("Started game");
    }

    private IEnumerator ButtonsFilledCheck()
    {
        yield return new WaitForEndOfFrame();
        checkAnswersButton.SetActive(CheckIfAllButtonsAreFilledIn());
    }

    private bool CheckIfAllButtonsAreFilledIn()
    {
        for (int i = 0; i < spawnedButtons.Count; i++)
        {
            if (spawnedButtons[i].currentNumber != -1) continue;
            return false;
        }
        return true;
    }

    private void MakeAllButtonsNonInteractable()
    {
        for (int i = 0; i < spawnedButtons.Count; i++)
        {
            spawnedButtons[i].button.interactable = false;
        }
    }

    public void CheckAnswers()
    {
        MakeAllButtonsNonInteractable();

        for (int i = 0; i < spawnedButtons.Count; i++)
        {
            var button = spawnedButtons[i];
            button.buttonBackground.color = (button.IsCorrect()) ? Color.green : Color.red;
        }
    }

    public void BackToMenu()
    {
        SceneLoader.LoadScene(Scenes.StartMenu);
    }

    private void OnDestroy()
    {
        Numpad.OnEnterNumber -= OnEnterNumber;
    }

    private void OnEnterNumber(int x)
    {
        memoryInputPanel.Close();
        StartCoroutine(ButtonsFilledCheck());
    }
}
