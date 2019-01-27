using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogEvent : MonoBehaviour
{

    private bool spriteOutOnLeft;
    private bool spriteOutOnRight;



    private DialogCanvasManager.CharactersToShow characterOnRight;
    private DialogCanvasManager.CharactersToShow characterOnLeft;

    public EventAction[] eventArray;

    private int actionNumber = 0;

    public void NextAction(int nextAction){

        DialogCanvasManager.instance.dialogBackground.gameObject.SetActive(true);

        EventAction currentAction = eventArray[nextAction];
        actionNumber = nextAction;

        if(currentAction.LeftCharacter != DialogCanvasManager.CharactersToShow.NONE){

            if(!spriteOutOnLeft){
                DialogCanvasManager.instance.ShowCharacterLeft(currentAction.LeftCharacter);
                DialogCanvasManager.instance.ShowLeftDialogBox(currentAction.LeftCharacter);
                characterOnLeft = currentAction.LeftCharacter;
                spriteOutOnLeft = true;
            } else if(characterOnLeft != currentAction.LeftCharacter){
                DialogCanvasManager.instance.HideCharacterLeft();
                DialogCanvasManager.instance.ShowCharacterLeft(currentAction.LeftCharacter);
                DialogCanvasManager.instance.ShowLeftDialogBox(currentAction.LeftCharacter);
                characterOnLeft = currentAction.LeftCharacter;
                spriteOutOnLeft = true;
            }
        } else if (currentAction.LeftCharacter == DialogCanvasManager.CharactersToShow.NONE){
            if(spriteOutOnLeft){
                DialogCanvasManager.instance.HideCharacterLeft();
                DialogCanvasManager.instance.HideLeftDialog();
                spriteOutOnLeft = false;
                characterOnLeft = DialogCanvasManager.CharactersToShow.NONE;
            }

        }

        if(currentAction.RightCharacter != DialogCanvasManager.CharactersToShow.NONE){

            if(!spriteOutOnRight){

                DialogCanvasManager.instance.ShowCharacterRight(currentAction.RightCharacter);
                DialogCanvasManager.instance.ShowRightDialogBox(currentAction.RightCharacter);
                characterOnRight = currentAction.LeftCharacter;
                spriteOutOnRight = true;

            } else if(characterOnRight != currentAction.RightCharacter){

                DialogCanvasManager.instance.HideCharacterRight();
                DialogCanvasManager.instance.ShowCharacterRight(currentAction.RightCharacter);
                DialogCanvasManager.instance.ShowRightDialogBox(currentAction.RightCharacter);
                characterOnLeft = currentAction.LeftCharacter;
                spriteOutOnRight = true;

            } 
            
        } else{
            DialogCanvasManager.instance.HideCharacterRight();
            DialogCanvasManager.instance.HideRightDialog();
            spriteOutOnRight = false;
            characterOnRight = DialogCanvasManager.CharactersToShow.NONE;
        }

        if(currentAction.LeftCharacter == DialogCanvasManager.CharactersToShow.NONE && currentAction.RightCharacter == DialogCanvasManager.CharactersToShow.NONE){
            DialogCanvasManager.instance.HideRightDialog();
            DialogCanvasManager.instance.HideLeftDialog();

            if(characterOnRight != DialogCanvasManager.CharactersToShow.NONE){
                DialogCanvasManager.instance.HideCharacterRight();
            }

            if(characterOnLeft != DialogCanvasManager.CharactersToShow.NONE){
                DialogCanvasManager.instance.HideCharacterLeft();
            }


        }

        if(spriteOutOnRight && currentAction.showLeftName){
            DialogCanvasManager.instance.ShowLeftDialogBox(currentAction.LeftCharacter);
        } else if(spriteOutOnRight && currentAction.showRightName){
            DialogCanvasManager.instance.ShowRightDialogBox(currentAction.RightCharacter);
        }

        if(currentAction.showChoices){
            DialogCanvasManager.instance.ShowButtonChoices(currentAction.choice1Text, currentAction.choice2Text, currentAction.firstButtonTargetEvent, currentAction.secondButtonTargetEvent);
        }

        if(currentAction.playerStat != EventAction.PlayerStatToModify.NONE){
            ModifyPlayerStats(currentAction.playerStat, currentAction.playerStatAmount);
        }

        if(currentAction.familyStat != EventAction.FamilyStatToModify.NONE){
            ModifyFamilyStats(currentAction.familyStat, currentAction.familyStatAmount, currentAction.familyMemberToAffect);

        }
            
        DialogCanvasManager.instance.ShowEventDialog(currentAction.dialogText);

        if(currentAction.insertEndingScene.Length >1){
            
            SceneManager.LoadScene(currentAction.insertEndingScene);
        }
        

    }

    public void ModifyPlayerStats(EventAction.PlayerStatToModify statToModify, int amount){

        switch(statToModify){

            case EventAction.PlayerStatToModify.CHARISMA:
            PlayerStatsManager.instance.charisma += amount;
            break;

            case EventAction.PlayerStatToModify.KNOWLEDGE:
            PlayerStatsManager.instance.knowledge += amount;
            break;

            case EventAction.PlayerStatToModify.ENERGY:
            PlayerStatsManager.instance.energy += amount;
            break;

            case EventAction.PlayerStatToModify.MOOD:
            PlayerStatsManager.instance.mood += amount;
            break;
        }

    }

    public void ModifyFamilyStats(EventAction.FamilyStatToModify statToModify, int amount, DialogCanvasManager.CharactersToShow character){

        string nameString = null;

        switch(character){
            case DialogCanvasManager.CharactersToShow.MOM:
           nameString = "mother";
           break;

           case DialogCanvasManager.CharactersToShow.DAD:
           nameString = "father";
           break;

           case DialogCanvasManager.CharactersToShow.SISTER:
           nameString = "sister";
           break;

           case DialogCanvasManager.CharactersToShow.BROTHER:
           nameString = "brother";
           break;

           case DialogCanvasManager.CharactersToShow.ALL:
            nameString = "all";
           break;
        }

        switch(statToModify){

            case EventAction.FamilyStatToModify.MOOD:
            CharacterManager.instance.changeMood(amount, nameString);
            break;

            case EventAction.FamilyStatToModify.LOYALTY:
            CharacterManager.instance.changeLoyalty(amount, nameString);
            break;

            case EventAction.FamilyStatToModify.RELATIONSHIP:
            CharacterManager.instance.changeRelationship(amount, nameString);
            break;

        }

    }

    private void Update() {
        if(Input.GetMouseButtonUp(0) && actionNumber < eventArray.Length && !DialogCanvasManager.instance.isInChoice){
            NextAction(actionNumber);
            actionNumber++;
        }
    }


}
