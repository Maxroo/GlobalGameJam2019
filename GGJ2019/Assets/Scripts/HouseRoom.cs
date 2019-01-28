using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseRoom : MonoBehaviour
{
   public string roomSceneName;
   public string[] roomActions;
   public BackgroundManager.RoomNames roomType;

   private void Awake() {
       GetComponent<Button>().onClick.AddListener(ButtonAction);
   }

   public void ButtonAction(){
    AudioManager.instance.PlayClickSoundEffect();
       RoomCanvasManager.instance.ShowRoom(roomSceneName, roomActions, roomType);

   }
}
