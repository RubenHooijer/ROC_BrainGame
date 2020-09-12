using UnityEngine;
using UnityEditor;
using TMPro;

public class SpawnObjectsInCircle : ScriptableWizard
{
    [Tooltip("First object of the circle")]
    public GameObject objectToSpawn;
    public Transform pivotPoint;
    [Space()]
    [Header("Settings")]
    public bool useCopyCounter = true;
    [Range(1, 360)]
    public int amountOfCopies = 1;
    public bool countText = false;

    [MenuItem("Custom/Spawn objects in circle")]


    static void CreateWizard()
    {
        DisplayWizard("Spawn objects in circle", typeof(SpawnObjectsInCircle), "Spawn");
    }

    void OnWizardCreate()
    {

        float radius = Vector2.Distance(pivotPoint.position, objectToSpawn.transform.position);

        for (int i = 0; i < amountOfCopies; i++)
        {
            //Distance around the circle
            float radians = Mathf.PI * 2f / amountOfCopies * i;

            float x = -Mathf.Cos(radians + Mathf.PI / 2);
            float y = Mathf.Sin(radians + Mathf.PI / 2);

            Debug.Log("Sin: " + y + "\nCos: " + x);
            //Vector direction
            var spawnDir = new Vector2(x, y);

            //Get the spawn position
            var spawnPos = new Vector2(pivotPoint.position.x, pivotPoint.position.y) + spawnDir * radius;

            GameObject obj = Instantiate(objectToSpawn);
            obj.transform.position = spawnPos;
            obj.transform.SetParent(objectToSpawn.transform.parent);

            if (useCopyCounter) obj.name = $"{objectToSpawn.name} ({i})";

            obj.GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
        }
    }
}