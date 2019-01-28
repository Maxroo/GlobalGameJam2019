using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageDisplay : MonoBehaviour
{

    public Room roomToCheck;
    public Image[] characterSprites;

    private void Awake() {
        CharacterManager.OnCharactersShuffled += checkCharactersInRoom;
    }

    private void Start() {
        checkCharactersInRoom();
    }

    public void checkCharactersInRoom(){

        FamilyCharacter[] chars = CharacterManager.instance.GetCharacters();
       for(int i = 0; i < 4; i++){
           
           if(chars[i].currentRoom == roomToCheck){
               characterSprites[i].enabled = true;
           } else{
               characterSprites[i].enabled = false;
           }
       }

    }

    private void OnDestroy() {
        CharacterManager.OnCharactersShuffled -= checkCharactersInRoom;
    }

    private void OnDisable() 
    {
        CharacterManager.OnCharactersShuffled -= checkCharactersInRoom;
    }


}
