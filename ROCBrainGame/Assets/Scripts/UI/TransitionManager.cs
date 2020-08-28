using System;
using System.Collections;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
	private const string TRANSITION_STRING = "Transition";

    private static TransitionManager _instance;

	public static Action OnPeakTransition;

	[Header("References: ")]
	[SerializeField]
	private Animator _blueSlimeTransition;
	[SerializeField]
	private Animator _pinkSlimeTransition;
	[SerializeField]
	private Animator _pinkBrainTransition;
	[SerializeField]
	private Animator _blueBrainTransition;

	private static Animator s_blueSlimeTransition;
	private static Animator s_pinkSlimeTransition;
	private static Animator s_pinkBrainTransition;
	private static Animator s_blueBrainTransition;

	private static Animator _currentTransition;

	private static Canvas _canvas;

	private void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		} else
		{
			Destroy(gameObject);
		}
	}

	private void Start()
	{
		s_blueBrainTransition = _blueBrainTransition;
		s_pinkBrainTransition = _pinkBrainTransition;
		s_blueSlimeTransition = _blueSlimeTransition;
		s_pinkSlimeTransition = _pinkSlimeTransition;

		s_blueBrainTransition.speed = s_blueBrainTransition.speed * 10;
		s_pinkBrainTransition.speed = s_pinkBrainTransition.speed * 10;
		s_blueSlimeTransition.speed = s_blueSlimeTransition.speed * 10;
		s_pinkSlimeTransition.speed = s_pinkSlimeTransition.speed * 10;

		_blueBrainTransition = null;
		_pinkBrainTransition = null;
		_blueSlimeTransition = null;
		_pinkSlimeTransition = null;

		_canvas = GetComponent<Canvas>();

		_instance.StartCoroutine(quickFinishAnimations());

		IEnumerator quickFinishAnimations()
		{
			yield return new WaitForSeconds(0.4f);
			s_blueBrainTransition.speed = s_blueBrainTransition.speed / 10;
			s_pinkBrainTransition.speed = s_pinkBrainTransition.speed / 10;
			s_blueSlimeTransition.speed = s_blueSlimeTransition.speed / 10;
			s_pinkSlimeTransition.speed = s_pinkSlimeTransition.speed / 10;
		}
	}

	public static void DoTransition(Transitions transition, Action onPeakAction = null, bool autoClose = true)
	{
		switch (transition)
		{
			case Transitions.BlueSlime:
				_currentTransition = s_blueSlimeTransition;
				break;
			case Transitions.PinkSlime:
				_currentTransition = s_pinkSlimeTransition;
				break;
			case Transitions.PinkBrain:
				_currentTransition = s_pinkBrainTransition;
				break;
			case Transitions.BlueBrain:
				_currentTransition = s_blueBrainTransition;
				break;
			default:
				break;
		}

		_canvas.sortingOrder = 10;

		if(onPeakAction != null)
		{
			OnPeakTransition += onPeakAction;
		}

		if (autoClose)
		{
			OnPeakTransition += CloseTransition;
		}

		_currentTransition.SetBool(TRANSITION_STRING, true);
	}

	//Gets called by animation
	public void PeakTransition()
	{
		OnPeakTransition?.Invoke();
		OnPeakTransition = null;
	}

	public static void CloseTransition()
	{
		_instance.StartCoroutine(closeTransition());

		IEnumerator closeTransition()
		{
			yield return new WaitUntil(IsCurrentAnimationDone);
			_currentTransition.SetBool(TRANSITION_STRING, false);
		}
	}

	private static bool IsCurrentAnimationDone()
	{
		return (_currentTransition.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);
	}
}

public enum Transitions
{
	BlueSlime = 0,
	PinkSlime = 1,
	PinkBrain = 2,
	BlueBrain = 4
}
