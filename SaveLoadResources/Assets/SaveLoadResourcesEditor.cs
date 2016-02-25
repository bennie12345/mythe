using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof(SaveLoadResources))]

public class SaveLoadResourcesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SaveLoadResources saveLoadResources = (SaveLoadResources)target;

        DrawDefaultInspector();
        //EditorGUILayout.LabelField("Gold", saveLoadResources.Gold.ToString());
        GUILayout.BeginHorizontal();
        if(GUILayout.Button("Save Game"))
        {
            saveLoadResources.SaveResources();
        }

        if (GUILayout.Button("Load Game"))
        {
            saveLoadResources.LoadResources();
        }
        GUILayout.EndHorizontal();
    }
}
