using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomOption : MonoBehaviour
{
  
    public int buttonID;

    private void Awake() {
       GetComponent<Button>().onClick.AddListener(OnPressAction);
    }

    public void OnPressAction(){

        string actionSceneId = RoomCanvasManager.instance.buttonText[buttonID].text.ToLower().Replace(' ', '.');
        SceneManager.LoadScene(actionSceneId, LoadSceneMode.Additive);
        RoomCanvasManager.instance.HideButtons();
        

    }

}
