using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitManager : MonoBehaviour {

    private CanvasGroup confirmationBtnCanvas;

    private void Start() {
        confirmationBtnCanvas = GetComponentInChildren<CanvasGroup>();
        confirmationBtnCanvas.alpha = 0;

        confirmationBtnCanvas.interactable = false;
        confirmationBtnCanvas.blocksRaycasts = false;
    }
    
    public void QuitGame() {
        ShowConfirmationButtons();
    }

    private void ShowConfirmationButtons() {
        confirmationBtnCanvas.interactable = true;
        confirmationBtnCanvas.blocksRaycasts = true;
        confirmationBtnCanvas.alpha = 1;
    }

    public void YesOptionSelected() {
        Application.Quit();
    }

    public void NoOptionSelect() {
        confirmationBtnCanvas.alpha = 0;
        confirmationBtnCanvas.interactable = false;
        confirmationBtnCanvas.blocksRaycasts = false;
    }
}
