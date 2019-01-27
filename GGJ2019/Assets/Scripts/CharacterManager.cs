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

    private void Awake() {
        if(instance != null){
            Destroy(this);
        }
        instance = this;
        characterList = new FamilyCharacter[]  {mother, father, sister, brother, dog };
}

    public FamilyCharacter[] GetCharacters()
    {
        return characterList;
    }

    public void changeMood(int amountChanged, string characterToChange){

        FamilyCharacter currentCharacter = null;
        switch(characterToChange.ToLower()){

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

        if(currentCharacter != null){
            currentCharacter.mood += amountChanged;
        } else
        {
            mother.mood += amountChanged;
            father.mood += amountChanged;
            sister.mood += amountChanged;
            brother.mood += amountChanged;
            
        }
    }

    public void changeLoyalty(int amountChanged, string characterToChange){

        FamilyCharacter currentCharacter = null;
        switch(characterToChange.ToLower()){

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

        if(currentCharacter != null){
            currentCharacter.loyalty += amountChanged;
        } else
        {
            mother.loyalty += amountChanged;
            father.loyalty += amountChanged;
            sister.loyalty += amountChanged;
            brother.loyalty += amountChanged;
            
        }
    }

    public void changeRelationship(int amountChanged, string characterToChange){

        FamilyCharacter currentCharacter = null;
        switch(characterToChange.ToLower()){

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

        if(currentCharacter != null){
            currentCharacter.relationship += amountChanged;
        } else {
            mother.relationship += amountChanged;
            father.relationship += amountChanged;
            sister.relationship += amountChanged;
            brother.relationship += amountChanged;     
        }

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
