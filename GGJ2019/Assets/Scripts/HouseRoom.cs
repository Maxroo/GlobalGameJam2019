using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseRoom : MonoBehaviour
{
    // Start is called before the first frame update
   FamilyMember[] charactersInRoom;
   public string roomSceneName;
   public string[] roomActions;
   public BackgroundManager.RoomNames roomType;

   private void Awake() {
       GetComponent<Button>().onClick.AddListener(ButtonAction);
   }

   public void ButtonAction(){
       RoomCanvasManager.instance.ShowRoom(roomSceneName, roomActions, roomType);

   }
}
