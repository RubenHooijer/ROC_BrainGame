using UnityEngine;
using UnityEngine.UI;

public class KennisFaults : MonoBehaviour
{
    [Header("Settings: ")]
    [SerializeField] private Color _faultMadeColor;

    [Header("References: ")]
    [SerializeField] private Image[] _faults;

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
        for (int i = 0; i < _faults.Length; i++)
        {
            if (_faults[i].color == _faultMadeColor) continue;
            _faults[i].color = _faultMadeColor;
            return;
        }
    }
}
