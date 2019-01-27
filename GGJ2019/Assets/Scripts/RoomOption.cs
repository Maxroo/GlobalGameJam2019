using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomOption : MonoBehaviour
{
  
    public int buttonID;

    private void Awake() {
       GetComponent<Button>().onClick.AddListener(OnPressAction);
    }

    public void OnPressAction(){

        string actionSceneId = RoomCanvasManager.instance.buttonText[buttonID].text.ToLower().Replace(' ', '.');
        print(actionSceneId);

    }

}
