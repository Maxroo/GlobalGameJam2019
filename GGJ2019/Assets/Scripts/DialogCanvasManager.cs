using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogCanvasManager : MonoBehaviour
{
    public static DialogCanvasManager instance;

    public enum CharactersToShow{
        MOM,
        DAD,
        SISTER,
        BROTHER,
        DOG,
        NONE
    }

    [Header("Buttons")]
    public Button FirstOption;
    public Button SecondOption;

    [Header("Images")]
   public Image leftDialogBox;
   public Image rightDialogBox;
   public Image dialogBackground;

   [Header("Text")]
    public Text leftDialogName;
   public Text rightDialogName;
   public Text dialogText;
   public Text firstButtonText;

   [Header("CharacterSprites")]
   public Image momSprite;
   public Image dadSprite;
   public Image sisSprite;
   public Image broSprite;

   private Image leftSprite;
   private Image rightSprite;

   private void Awake() {

       if(instance != null){
           instance = this;
       }
       instance = this;

   }

   public void ShowLeftDialogBox(CharactersToShow character){
       leftDialogBox.gameObject.SetActive(true);

       string nameString = null;
       switch(character){

           case DialogCanvasManager.CharactersToShow.MOM:
           nameString = "Mom";
           break;

           case DialogCanvasManager.CharactersToShow.DAD:
           nameString = "Dad";
           break;

           case DialogCanvasManager.CharactersToShow.SISTER:
           nameString = "Sister";
           break;

           case DialogCanvasManager.CharactersToShow.BROTHER:
           nameString = "Brother";
           break;

       }

       leftDialogName.text = nameString;
   }

   public void ShowRightDialogBox(CharactersToShow character){
       rightDialogBox.gameObject.SetActive(true);

        string nameString = null;

       switch(character){
           case DialogCanvasManager.CharactersToShow.MOM:
           nameString = "Mom";
           break;

           case DialogCanvasManager.CharactersToShow.DAD:
           nameString = "Dad";
           break;

           case DialogCanvasManager.CharactersToShow.SISTER:
           nameString = "Sister";
           break;

           case DialogCanvasManager.CharactersToShow.BROTHER:
           nameString = "Brother";
           break;
       }
       
       rightDialogName.text = nameString;
   }

   public void HideRightDialog(){
       rightDialogBox.gameObject.SetActive(false);
   }

   public void HideLeftDialog(){
       leftDialogBox.gameObject.SetActive(false);
   }

   public void HideDialogNames(){
        rightDialogBox.gameObject.SetActive(false);
        leftDialogBox.gameObject.SetActive(false);
   }

   public void ShowEventDialog(string dialogString){
       dialogBackground.gameObject.SetActive(true);
       dialogText.text = dialogString;
   }

   public void ShowCharacterLeft(CharactersToShow character){

       Image spriteToShow = null;

       switch(character){
           case DialogCanvasManager.CharactersToShow.MOM:
           spriteToShow = momSprite;
           break;

           case DialogCanvasManager.CharactersToShow.DAD:
           spriteToShow = dadSprite;
           break;

           case DialogCanvasManager.CharactersToShow.SISTER:
           spriteToShow = sisSprite;
           break;

           case DialogCanvasManager.CharactersToShow.BROTHER:
           spriteToShow = broSprite;
           break;
       }

       if(spriteToShow != null){

            spriteToShow.enabled = true;
            spriteToShow.rectTransform.localScale= new Vector3(-1, 1, 1);
            leftSprite = spriteToShow;
            leftSprite.gameObject.GetComponent<SpriteMovement>().MoveInLeft();

       }

   }



    public void ShowCharacterRight(CharactersToShow character){

       Image spriteToShow = null;

       switch(character){
           case DialogCanvasManager.CharactersToShow.MOM:
           spriteToShow = momSprite;
           break;

           case DialogCanvasManager.CharactersToShow.DAD:
           spriteToShow = dadSprite;
           break;

           case DialogCanvasManager.CharactersToShow.SISTER:
           spriteToShow = sisSprite;
           break;

           case DialogCanvasManager.CharactersToShow.BROTHER:
           spriteToShow = broSprite;
           break;
       }
        if(spriteToShow != null){
            spriteToShow.enabled = true;
            spriteToShow.rectTransform.localScale= new Vector3(-1, 1, 1);
            rightSprite = spriteToShow;
            rightSprite.gameObject.GetComponent<SpriteMovement>().MoveInRight();

        }
   }

  

   public void HideCharacterLeft(){
       leftSprite.gameObject.GetComponent<SpriteMovement>().MoveOutLeft();

   }

    public void HideCharacterRight(){
        if(rightSprite != null){

            rightSprite.gameObject.GetComponent<SpriteMovement>().MoveOutRight();
        }

    }

 

}
