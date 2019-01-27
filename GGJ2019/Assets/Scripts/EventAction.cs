using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Dialog", menuName = "SceneEvents", order = 1)]
public class EventAction : ScriptableObject
{
    public enum FamilyStatToModify{

        NONE,
        MOOD,
        LOYALTY,
        RELATIONSHIP

    }

    public enum PlayerStatToModify{

        NONE,
        MOOD,
        CHARISMA,
        KNOWLEDGE,
        ENERGY

    }

    public enum MusicChoices{
        NEUTRAL,
        POSITIVE,
        NEGATIVE,
        INTENSE
    }

    public enum TimeRequirement{

        Morning,
        Afternoon,
        Noon,
        Night,
        Anytime

    }

    


    public TimeRequirement timeRequirement = TimeRequirement.Anytime;
    public DialogCanvasManager.CharactersToShow LeftCharacter;
    public DialogCanvasManager.CharactersToShow RightCharacter;
    public string dialogText;
    public bool showChoices;

    public string choice1Text;
    public string choice2Text;

    public int firstButtonTargetEvent;
    public int secondButtonTargetEvent;

    public bool showLeftName;
    public bool showRightName;


    public FamilyStatToModify familyStat = FamilyStatToModify.NONE;
    public DialogCanvasManager.CharactersToShow familyMemberToAffect;
    public PlayerStatToModify playerStat = PlayerStatToModify.NONE;


    public bool isEnd;
    public bool moveTime;


    public int familyStatAmount;
    public int playerStatAmount;

    public BackgroundManager.RoomNames backgroundToLoad;

    public bool changeMusic;
    public MusicChoices musicToSet;

  
    public string insertEndingScene;


    public static void CreateMyAsset()
    {
        EventAction asset = ScriptableObject.CreateInstance<EventAction>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }

}
