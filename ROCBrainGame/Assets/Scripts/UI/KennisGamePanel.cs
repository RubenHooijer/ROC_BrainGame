using UnityEngine;

public class KennisGamePanel : UIPanel
{
    [Header("References: ")]
    [SerializeField] private KennisSpel kennisSpel;

    private void Start()
    {
        kennisSpel.SetupRound();
    }

    public override void Open()
    {
        kennisSpel.StartRound();
        base.Open();
    }

    public override void Close()
    {
        base.Close();
        kennisSpel.SetupRound();
    }
} 
