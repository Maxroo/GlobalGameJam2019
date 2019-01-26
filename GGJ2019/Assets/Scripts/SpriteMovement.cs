using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteMovement : MonoBehaviour
{

    Image imageRef;

    private void Awake() {
        imageRef = GetComponent<Image>();
        
    }

    public void MoveInLeft(){
        StartCoroutine(MoveLeftSpriteIn());

    }
     public void MoveOutLeft(){
        StartCoroutine(MoveLeftSpriteOut());

    } 
    public void MoveInRight(){
        StartCoroutine(MoveRightSpriteIn());

    } 
    public void MoveOutRight(){
        StartCoroutine(MoveRightSpriteOut());

    }


   IEnumerator MoveRightSpriteOut(){

       imageRef.rectTransform.anchoredPosition = new Vector2(240, 0);

        while(imageRef.rectTransform.anchoredPosition != new Vector2(515, 0)){
            imageRef.rectTransform.anchoredPosition = Vector2.MoveTowards(imageRef.rectTransform.anchoredPosition, new Vector2(515, 0), 10);
            yield return null;
        }
        
   }

    IEnumerator MoveLeftSpriteOut(){

       imageRef.rectTransform.anchoredPosition = new Vector2(-240, 0);

        while(imageRef.rectTransform.anchoredPosition != new Vector2(-515, 0)){
            imageRef.rectTransform.anchoredPosition = Vector2.MoveTowards(imageRef.rectTransform.anchoredPosition, new Vector2(-515, 0), 10);
            yield return null;
        }

   }

   IEnumerator MoveRightSpriteIn(){

       imageRef.rectTransform.anchoredPosition = new Vector2(515, 0);

        while(imageRef.rectTransform.anchoredPosition != new Vector2(240, 0)){
            imageRef.rectTransform.anchoredPosition = Vector2.MoveTowards(imageRef.rectTransform.anchoredPosition, new Vector2(240, 0), 10);
            yield return null;
        }
        
   }

    IEnumerator MoveLeftSpriteIn(){

       imageRef.rectTransform.anchoredPosition = new Vector2(-515, 0);

        while(imageRef.rectTransform.anchoredPosition != new Vector2(-240, 0)){
            imageRef.rectTransform.anchoredPosition = Vector2.MoveTowards(imageRef.rectTransform.anchoredPosition, new Vector2(-240, 0), 10);
            yield return null;
        }

   }
}
