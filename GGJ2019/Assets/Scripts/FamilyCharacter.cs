using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Char", menuName = "FamilyMember", order = 1)]
public class FamilyCharacter : ScriptableObject
{

    public int mood;
    public int loyalty;
    public int relationship;


    public static void CreateMyAsset()
    {
        EventAction asset = ScriptableObject.CreateInstance<EventAction>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
   
}
