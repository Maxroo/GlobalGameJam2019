using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomCanvasManager : MonoBehaviour
{
    // Start is called before the first frame update
    // public Text RoomNameText;
    public static RoomCanvasManager instance;
    CanvasGroup roomCanvas;
    public GameObject[] roomButtons;
    public Text[] buttonText;
    public GameObject backButton;

    private void Awake() {

        if(instance != null){
            Destroy(this);
        }
        instance = this;
        roomCanvas = GetComponent<CanvasGroup>();

    }

    public void ShowRoom(string roomName, string[] actions, BackgroundManager.RoomNames roomType){

        for(int i = 0; i < actions.Length; i++){

            roomButtons[i].SetActive(true);
            buttonText[i].text=actions[i];
            roomButtons[i].GetComponent<RoomOption>().buttonID = i;

        }

        
        BackgroundManager.instance.ShowRoomBackground(roomType);
        backButton.gameObject.SetActive(true);
        HouseManager.instance.HideHouse();
        // RoomNameText.text = roomName;
        roomCanvas.interactable = true;
        roomCanvas.blocksRaycasts = true;
        roomCanvas.alpha = 1;

    }



    public void HideRoom(){
        roomCanvas.interactable = false;
        roomCanvas.blocksRaycasts = false;
        roomCanvas.alpha = 0;
        BackgroundManager.instance.HideRoomBackgrounds();
        for(int i = 0; i < roomButtons.Length; i++){


            roomButtons[i].gameObject.SetActive(false);

        }
    }

    public void HideButtons(){
        for(int i = 0; i < roomButtons.Length; i++){
            roomButtons[i].gameObject.SetActive(false);
        }
        backButton.gameObject.SetActive(false);
    }

    public void OnBackButtonClicked(){
        HouseManager.instance.ShowHouse();
        HideRoom();
        BackgroundManager.instance.isInRoom = false;
        BackgroundManager.instance.checkIsInRoom();

    }
    
}
