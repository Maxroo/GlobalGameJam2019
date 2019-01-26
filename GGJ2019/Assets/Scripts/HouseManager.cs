using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static HouseManager instance;
    CanvasGroup houseCanvas;

    private void Awake() {
        if(instance != null){
            Destroy(this);
        }
        instance = this;

        houseCanvas = GetComponent<CanvasGroup>();
    }

    public void ShowHouse(){
      
        houseCanvas.interactable = true;
        houseCanvas.blocksRaycasts = true;
        houseCanvas.alpha = 1;

    }

    public void HideHouse(){

        houseCanvas.interactable = false;
        houseCanvas.blocksRaycasts = false;
        houseCanvas.alpha = 0;

    }

}
