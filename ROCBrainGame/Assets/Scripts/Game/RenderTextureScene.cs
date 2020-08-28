using System.Collections.Generic;
using UnityEngine;

public class RenderTextureScene : MonoBehaviour
{

    private static RenderTextureScene _instance;
    private static Dictionary<Condition, GameObject> conditionGameObjectPair = new Dictionary<Condition, GameObject>();
    private static Condition _currentActive = null;

    [SerializeField]
    private Condition[] _allConditions;

    private void Awake()
    {
        if(_instance == null)
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
        if (_instance != this) return;

        for (int i = 0; i < _allConditions.Length; i++)
        {
            var c = _allConditions[i];

            var obj = c.Spawn3dCharacter(transform.position);
            obj.SetActive(false);
            obj.transform.SetParent(transform);
            obj.name = c.name + " - 3DObject";

            conditionGameObjectPair.Add(c, obj);
        }
    }

    public static void ShowCondition(Condition condition)
    {
        if(_currentActive != null)
        {
            conditionGameObjectPair[_currentActive].SetActive(false);
        }

        conditionGameObjectPair[condition].SetActive(true);
        _currentActive = condition;
    }
}
