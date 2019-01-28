using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Buttons", menuName = "ActionButton", order = 1)]
public class ActionButtons : ScriptableObject
{
    
    public string buttonText;
    public string actionSceneID;

    //public static void CreateMyAsset()
    //{
    //    EventAction asset = ScriptableObject.CreateInstance<EventAction>();

    //    AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
    //    AssetDatabase.SaveAssets();

    //    EditorUtility.FocusProjectWindow();

    //    Selection.activeObject = asset;
    //}



}
