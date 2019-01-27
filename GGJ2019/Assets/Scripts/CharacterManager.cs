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

    private void Awake() {
        if(instance != null){
            Destroy(this);
        }
        instance = this;
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

        currentCharacter.mood += amountChanged;
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

        currentCharacter.loyalty += amountChanged;
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

        currentCharacter.relationship += amountChanged;

    }

}
