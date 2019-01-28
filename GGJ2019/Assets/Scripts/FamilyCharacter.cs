using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Char", menuName = "FamilyMember", order = 1)]
public class FamilyCharacter : ScriptableObject
{
    public string charName;
    
    public int mood;
    public int loyalty;
    public int relationship;

    public Room currentRoom = Room.Kitchen;

    public int[] percentChanceRooms;


    //public static void CreateMyAsset()
    //{
    //    EventAction asset = ScriptableObject.CreateInstance<EventAction>();

    //    AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
    //    AssetDatabase.SaveAssets();

    //    EditorUtility.FocusProjectWindow();

    //    Selection.activeObject = asset;
    //}
   
}
