using UnityEngine;

public class KennisGamePanel : UIPanel
{
    [Header("References: ")]
    [SerializeField] private KennisSpel kennisSpel;

    public override void Open()
    {
        kennisSpel.StartRound();
        base.Open();
    }
} 
