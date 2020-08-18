using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textComponent;

    private void OnEnable()
    {
        GetComponent<Slider>().onValueChanged.AddListener(OnChangeNumber);
    }

    private void OnDisable()
    {
        GetComponent<Slider>().onValueChanged.RemoveListener(OnChangeNumber);
    }

    public void OnChangeNumber(float number)
    {
        _textComponent.SetText(number.ToString());
    }
}
