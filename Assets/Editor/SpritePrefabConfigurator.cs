using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class SpritePrefabConfigurator : EditorWindow
{
    private List<GameObject> listOfChildren;
    
    private const string MAT_PATH = "Assets/Shaders/SpriteShadow.mat";

    [MenuItem("Window/Sprite Prefab Configurator")]
    public static void ShowWindow()
    {
        GetWindow<SpritePrefabConfigurator>("Sprite Prefab Configurator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Sprite Prefab Configurator", EditorStyles.boldLabel);
        if (GUILayout.Button("Fix Sprite Layers"))
        {
            AddSortingGroup();
        }
        
        if (GUILayout.Button("Fix Sprite Rotation"))
        {
            SpriteRotation();
        }
        
        if (GUILayout.Button("Add Shadows"))
        {
            AddShadows();
        }
        
    }

    private void AddSortingGroup()
    {
        foreach (GameObject gameObjects in Selection.gameObjects)
        {
            gameObjects.AddComponent<SortingGroup>();
        }
    }

    private void SpriteRotation()
    {
        foreach (GameObject gameObjects in Selection.gameObjects)
        {
            gameObjects.transform.rotation = Quaternion.Euler(45, 0, 0);
        }
    }
    
    private void AddShadows()
    {
        foreach (GameObject gameObjects in Selection.gameObjects)
        {

            if (gameObjects.transform.childCount == 0)
            {
                var sr = gameObjects.GetComponent<SpriteRenderer>();
                sr.receiveShadows = true;
                sr.shadowCastingMode = ShadowCastingMode.On;
                
                Material newMat = (Material) AssetDatabase.LoadAssetAtPath(MAT_PATH, typeof(Material));
                if(newMat != null)
                    Debug.Log("Asset loaded");
                else
                    Debug.Log("cant find asset");
             
                sr.material = newMat;
            }
            else
            {
                GetChildRecursive(gameObjects);
                foreach (GameObject child in listOfChildren)
                {
                    var sr = child.GetComponent<SpriteRenderer>();
                    sr.receiveShadows = true;
                    sr.shadowCastingMode = ShadowCastingMode.On;
                
                    Material newMat = (Material) AssetDatabase.LoadAssetAtPath(MAT_PATH, typeof(Material));
                    if(newMat != null)
                        Debug.Log("Asset loaded");
                    else
                        Debug.Log("cant find asset");
             
                    sr.material = newMat;
                }
                listOfChildren.Clear();
            }
        }
    }

    private void GetChildRecursive(GameObject obj){
        if (null == obj)
            return;
        
        listOfChildren.Add(obj);

        foreach (Transform child in obj.transform){
            if (null == child)
                continue;
            //child.gameobject contains the current child you can do whatever you want like add it to an array
            listOfChildren.Add(child.gameObject);
            GetChildRecursive(child.gameObject);
        }
    }
}
