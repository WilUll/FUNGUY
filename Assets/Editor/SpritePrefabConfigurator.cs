using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SpritePrefabConfigurator : EditorWindow
{
    [MenuItem("Window/Sprite Prefab Configurator")]
    public static void ShowWindow()
    {
        GetWindow<SpritePrefabConfigurator>("Sprite Prefab Configurator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Sprite Prefab Configurator", EditorStyles.boldLabel);
        if (GUILayout.Button("Configure"))
        {
            Configure();
        }
        
    }

    private void Configure()
    {
        foreach (GameObject gameObjects in Selection.gameObjects)
        {
            gameObjects.AddComponent<SortingGroup>();
            gameObjects.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
    }
}
