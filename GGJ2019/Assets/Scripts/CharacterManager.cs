using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

    public static CharacterManager instance;
    public FamilyCharacter mother;
    public FamilyCharacter father;
    public FamilyCharacter sister;
    public FamilyCharacter brother;
    public FamilyCharacter dog;

    private FamilyCharacter[] characterList;

    public Dictionary<Room, int> roomCaps = new Dictionary<Room, int>() { { Room.Kitchen, 2},{ Room.LivingRoom,2},{ Room.SunRoom,2},{ Room.KidsBedroom,2},{ Room.AdultsBedroom,2},{ Room.GameRoom,2},{ Room.Bathroom, 1} };


    private void Awake() {
        if (instance != null) {
            Destroy(this);
        }
        instance = this;
        characterList = new FamilyCharacter[] { mother, father, sister, brother, dog };
    }

    public FamilyCharacter[] GetCharacters()
    {
        return characterList;
    }

    public void changeMood(int amountChanged, string characterToChange) {

        FamilyCharacter currentCharacter = null;
        switch (characterToChange.ToLower()) {

            case "mother":
                currentCharacter = mother;
                break;

            case "father":
                currentCharacter = father;
                break;

            case "sister":
                currentCharacter = sister;
                break;

            case "brother":
                currentCharacter = brother;
                break;
        }

        if (currentCharacter != null) {
            currentCharacter.mood += amountChanged;
        } else
        {
            mother.mood += amountChanged;
            father.mood += amountChanged;
            sister.mood += amountChanged;
            brother.mood += amountChanged;

        }
    }

    public void changeLoyalty(int amountChanged, string characterToChange) {

        FamilyCharacter currentCharacter = null;
        switch (characterToChange.ToLower()) {

            case "mother":
                currentCharacter = mother;
                break;

            case "father":
                currentCharacter = father;
                break;

            case "sister":
                currentCharacter = sister;
                break;

            case "brother":
                currentCharacter = brother;
                break;
        }

        if (currentCharacter != null) {
            currentCharacter.loyalty += amountChanged;
        } else
        {
            mother.loyalty += amountChanged;
            father.loyalty += amountChanged;
            sister.loyalty += amountChanged;
            brother.loyalty += amountChanged;

        }
    }

    public void changeRelationship(int amountChanged, string characterToChange) {

        FamilyCharacter currentCharacter = null;
        switch (characterToChange.ToLower()) {

            case "mother":
                currentCharacter = mother;
                break;

            case "father":
                currentCharacter = father;
                break;

            case "sister":
                currentCharacter = sister;
                break;

            case "brother":
                currentCharacter = brother;
                break;
        }

        if (currentCharacter != null) {
            currentCharacter.relationship += amountChanged;
        } else {
            mother.relationship += amountChanged;
            father.relationship += amountChanged;
            sister.relationship += amountChanged;
            brother.relationship += amountChanged;
        }

    }

    public void ShuffleRooms()
    {
        for (int i = 0; i < characterList.Length; ++i)
        {
            if (Random.Range(0, 100) < ConstantsManager.kChanceOfMoveRoom) {
                Room randomRoom = GetRandomRoom(characterList[i]);
                if (roomCaps[randomRoom] >= CountCharactersInRoom(randomRoom))
                {
                    
                    characterList[i].currentRoom = randomRoom;
                    Debug.Log(characterList[i] + " -> " + characterList[i].currentRoom);

                }
                else
                {
                    --i;
                }
            }
        }
        string str = "";
        for (int i = 0; i < characterList.Length; ++i)
        {
            str += (characterList[i].charName + ": " + characterList[i].currentRoom + "\n");
        }
        Debug.Log(str);

    }

    private int CountCharactersInRoom( Room rm)
    {
        int count = 0;
        for (int i = 0; i <characterList.Length; ++i)
        {
            Debug.Log(characterList[i]);
            if (characterList[i].currentRoom == rm)
            {
                ++count;
            }
        }
        return count;
    }

    private Room GetRandomRoom(FamilyCharacter charToMove)
    {
        int random = Random.Range(0, 100);
        Room rtn = (Room)0;
        int currentSum = 0;
        for (int i = 0; i < charToMove.percentChanceRooms.Length; ++i)
        {
            currentSum += charToMove.percentChanceRooms[i];
            rtn = (Room)i;
            if (random < currentSum)
            {
                break;
            }
        }
        return rtn;
    }

}

public enum CharacterGroup
{
    None,
    Mother,
    Father,
    Brother,
    Sister,
    Pet,
    Humans,
    Adults,
    Kids,
    Female,
    Male,
    Any,
    All,
};
