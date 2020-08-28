using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorUnityEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _animatorEvent;

    public void InvokeUnityEvent()
    {
        _animatorEvent?.Invoke();
    }
}
