using System;
using System.Collections.Generic;
using UnityEngine;
using Extensions.List;

public class KennisSpel : MonoBehaviour
{
    public static Action UpdateFaultsMade;

    [Header("Settings: ")]
    [SerializeField] private int maxFaults = 3;

    [Header("References: ")]
    [SerializeField] private Condition[] allConditions;
    [SerializeField] private KennisGamePanel gamePanel;
    [SerializeField] private UIPanel positiveTransitionPanel;
    [SerializeField] private KennisWrongTransition negativeTransitionPanel;
    [SerializeField] private KennisResultPanel resultPanel;

    private List<int> conditionOrder = new List<int>();
    private int currentFaults = 0;
    private int conditionsSeen = -1;
    private Condition currentCondition = null;
    private List<string> wrongConditions = new List<string>();

    private void Awake()
    {
        UpdateFaultsMade += () => currentFaults += 1;
        Numpad.OnEnterNumber += CheckNumber;

        for (int i = 0; i < allConditions.Length; i++)
        {
            conditionOrder.Add(i);
        }

        conditionOrder.Shuffle();
    }

    private void OnDestroy()
    {
        Numpad.OnEnterNumber -= CheckNumber;
        UpdateFaultsMade -= () => currentFaults += 1;
    }

    private void Start()
    {
        UIManager.Instance.OpenPanel(gamePanel);
    }

    public void StartRound()
    {
        if(++conditionsSeen == allConditions.Length)
        {
            Debug.Log("You have seen all conditions");
            //Show results
            SetupResults();
            UIManager.Instance.OpenPanel(resultPanel);
            return;
        }

        currentCondition = allConditions[conditionOrder[conditionsSeen]];

        Debug.Log("New controlnumber is " + currentCondition.controlNumber);

        //Spawns the 3D character
        currentCondition.Spawn3dCharacter(Vector3.zero);
    }

    private void CheckNumber(int num)
    {
        if(num == currentCondition.controlNumber)
        {
            Debug.Log("You got it right");
            //Show positive transition screen
            PositiveTransition();
        } else
        {
            //Check for gameover
            if(currentFaults < maxFaults)
            {
                Debug.Log("You got it WRONG");
                //Show negative transition screen
                NegativeTransition();
            } else
            {
                Debug.Log("GAME OVER!");
                //Show results
                SetupResults();
            }
        }
        currentCondition.Discard();
    }

    private void PositiveTransition()
    {
        UIManager.Instance.OpenPanel(positiveTransitionPanel);
        if ((conditionsSeen + 1) < allConditions.Length)
        {
            UIManager.Instance.NextPanel = gamePanel;
        } else
        {
            SetupResults();
            UIManager.Instance.NextPanel = resultPanel;
        }
    }

    private void NegativeTransition()
    {
        wrongConditions.Add(currentCondition.name);
        negativeTransitionPanel.ChangeHeader(currentCondition.name);
        UIManager.Instance.OpenPanel(negativeTransitionPanel);
        if (currentFaults < maxFaults && ((conditionsSeen + 1) < allConditions.Length))
        {
            UIManager.Instance.NextPanel = gamePanel;
        } else
        {
            SetupResults();
            UIManager.Instance.NextPanel = resultPanel;
        }
    }

    private void SetupResults()
    {
        resultPanel.ChangeHeader("{Header text}");
        resultPanel.ShowScore((conditionsSeen + 1) - currentFaults);
        resultPanel.ShowWrongAnswers(wrongConditions.ToArray());
    }

    public void BackToMenu()
    {
        SceneLoader.LoadScene(Scenes.StartMenu);
    }
}
