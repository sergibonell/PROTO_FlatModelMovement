using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnumObject))]
public class EnumManagerEditor : Editor
{
    EnumObject enumManager;
    string filePath = "Assets/Scripts/Enums/";
    string fileName = "Test";

    private void OnEnable()
    {
        enumManager = (EnumObject)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        fileName = enumManager.name;

        filePath = EditorGUILayout.TextField("Path", filePath);
        fileName = EditorGUILayout.TextField("Name", fileName);
        if(GUILayout.Button("Save"))
        {
            EditorTools.WriteToEnum(filePath, fileName, enumManager.names);
        }
    }
}
