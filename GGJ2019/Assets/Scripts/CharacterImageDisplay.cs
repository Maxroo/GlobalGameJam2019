using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterImageDisplay : MonoBehaviour
{

    public Room roomToCheck;
    public Image[] characterSprites;

    public void checkCharactersInRoom(){

        FamilyCharacter[] chars = CharacterManager.instance.GetCharacters();
       for(int i = 0; i < chars.Length; i++){
           
           if(chars[i].currentRoom == roomToCheck){
               characterSprites[i].enabled = true;
           } else{
               characterSprites[i].enabled = false;
           }
       }

    }


}
