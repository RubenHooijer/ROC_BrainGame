﻿using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ReplaceGameObjects : ScriptableWizard
{
    public bool copyValues = true;
    public GameObject useInstead;
    public List<GameObject> toBeReplaced;

    [MenuItem("Custom/Replace GameObjects")]


    static void CreateWizard()
    {
        DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        for (int i = 0; i < toBeReplaced.Count; i++)
        {
            Replace(toBeReplaced[i]);
        }
    }

    private void Replace(GameObject toBeReplaced)
    {
        GameObject newObject;
        newObject = (GameObject)PrefabUtility.InstantiatePrefab(useInstead, toBeReplaced.transform.parent);
        newObject.transform.position = toBeReplaced.transform.position;
        newObject.transform.rotation = toBeReplaced.transform.rotation;
        newObject.transform.localScale = toBeReplaced.transform.localScale;

        DestroyImmediate(toBeReplaced);
    }
}