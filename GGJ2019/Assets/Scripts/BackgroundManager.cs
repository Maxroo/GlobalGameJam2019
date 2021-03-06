﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
    public enum RoomNames{
        NONE,
        LIVING_ROOM,
        PARENT_BEDROOM,
        KID_BEDROOM,
        BATHROOM,
        KITCHEN,
        GAME_ROOM,
        SUN_ROOM
    }

    public static BackgroundManager instance;

    public Image houseOverview;
    public Image outside;
    public Image[] roomBackgrounds;
    CanvasGroup backgroundsCanvas;
    Image currentBackground;

    public bool isInRoom = false;

    private void Awake() {

        if(instance != null){
            Destroy(this);
        }
        instance = this;

        backgroundsCanvas = GetComponent<CanvasGroup>();
        checkIsInRoom();
    }


    public void ShowRoomBackground(RoomNames roomToShow){
        currentBackground = null;
        isInRoom = true;
        checkIsInRoom();
        switch(roomToShow){

            case BackgroundManager.RoomNames.LIVING_ROOM:
            currentBackground = roomBackgrounds[1];
            break;

            case BackgroundManager.RoomNames.BATHROOM:
            currentBackground = roomBackgrounds[2];
            break;

            case BackgroundManager.RoomNames.KITCHEN:
            currentBackground = roomBackgrounds[0];
            break;

            case BackgroundManager.RoomNames.GAME_ROOM:
            currentBackground = roomBackgrounds[5];
            break;

            case BackgroundManager.RoomNames.SUN_ROOM:
            currentBackground = roomBackgrounds[6];
            break;

            case BackgroundManager.RoomNames.PARENT_BEDROOM:
            currentBackground = roomBackgrounds[3];
            break;

            case BackgroundManager.RoomNames.KID_BEDROOM:
            currentBackground = roomBackgrounds[4];
            break;
            
        }

        backgroundsCanvas.alpha = 1;

        if(currentBackground != null){
            currentBackground.enabled = true;
        }
    }

    public void HideRoomBackgrounds(){
        currentBackground.enabled = false;
        Invoke("HideBackgroundsCanvas", .2f);
        
    }

    public void HideBackgroundsCanvas(){
    }


    public void checkIsInRoom()
    {
        if(!isInRoom)
        {
            houseOverview.enabled = true;
        }else
        {
            houseOverview.enabled = false;            
        }
    }

}
