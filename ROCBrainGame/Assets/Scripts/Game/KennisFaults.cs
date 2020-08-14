using UnityEngine;

public class KennisFaults : MonoBehaviour
{
    [Header("References: ")]
    [SerializeField] private GameObject[] faults;

    private void Awake()
    {
        KennisSpel.UpdateFaultsMade += UpdateFaults;
    }

    private void OnDestroy()
    {
        KennisSpel.UpdateFaultsMade -= UpdateFaults;
    }

    private void UpdateFaults()
    {
        for (int i = 0; i < faults.Length; i++)
        {
            if (faults[i].activeSelf) continue;
            faults[i].SetActive(true);
            return;
        }
    }
}
