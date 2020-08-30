using UnityEngine;

[CreateAssetMenu(fileName = "New condition", menuName = "Game/Condition")]
public class Condition : ScriptableObject
{
    public int controlNumber = 1;
    public new string name = "New condition";
    [TextArea(5, 10)]
    public string description = "Type description...";

    [Space()]
    public Sprite icon = null;
    [SerializeField] 
    private CharacterizedCondition _characterPrefab;

    public GameObject Spawn3dCharacter(Vector3 position)
    {
        if (_characterPrefab == null) return null;
        var spawnedObject = Instantiate(_characterPrefab, position, Quaternion.identity);

        return spawnedObject.gameObject;
    }

#if UNITY_EDITOR
    [EasyAttributes.Button]
    private void SetFileName()
    {
        string assetPath = UnityEditor.AssetDatabase.GetAssetPath(this);
        UnityEditor.AssetDatabase.RenameAsset(assetPath, $"{controlNumber}_{name}");
        UnityEditor.AssetDatabase.SaveAssets();
    }
#endif
}
