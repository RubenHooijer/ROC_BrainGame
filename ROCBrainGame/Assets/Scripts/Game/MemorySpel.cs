using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Extensions.List;
using System.Collections;

public class MemorySpel : MonoBehaviour
{

    [Header("References: ")]
    [SerializeField] private Condition[] _allConditions;

    [Space()]
    [SerializeField] private Slider _setupSlider;
    [SerializeField] private ConditionButton _conditionButtonPrefab;
    [SerializeField] private Transform _buttonGroup;

    [Space()]
    [SerializeField] private MemoryDescriptionPanel _memoryDescriptionPanel;
    [SerializeField] private MemoryInputPanel _memoryInputPanel;
    [SerializeField] private GameObject _checkAnswersButton;

    [Space()]
    [SerializeField] private Sprite _buttonCorrect;
    [SerializeField] private Sprite _buttonWrong;


    private int amountOfConditions;
    private List<ConditionButton> spawnedButtons = new List<ConditionButton>();

    public void SetupGame()
    {
        amountOfConditions = (int)_setupSlider.value;

        List<int> conditionOrder = new List<int>();

        for (int i = 0; i < _allConditions.Length; i++)
        {
            conditionOrder.Add(i);
        }

        conditionOrder.Shuffle();

        for (int i = 0; i < amountOfConditions; i++)
        {
            var obj = Instantiate(_conditionButtonPrefab, _buttonGroup);
            obj.Condition = _allConditions[conditionOrder[i]];
            obj.button.onClick.AddListener(() => _memoryDescriptionPanel.AssignCondition(obj.Condition));

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
            button.button.onClick.AddListener(() => _memoryInputPanel.Show(button));
        }

        Numpad.OnEnterNumber += OnEnterNumber;
        Debug.Log("Started game");
    }

    private IEnumerator ButtonsFilledCheck()
    {
        yield return new WaitForEndOfFrame();
        _checkAnswersButton.SetActive(CheckIfAllButtonsAreFilledIn());
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
            button.buttonBackground.sprite = (button.IsCorrect()) ? _buttonCorrect : _buttonWrong;
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
        _memoryInputPanel.Close();
        StartCoroutine(ButtonsFilledCheck());
    }
}
