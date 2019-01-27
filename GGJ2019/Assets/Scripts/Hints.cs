using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour {

    [SerializeField] float smoothness = 0.02f;
    [SerializeField] float timeShowingHint = 3;
    private CanvasGroup hintCanvas;

    // Start is called before the first frame update
    void Start() {
        hintCanvas = GetComponent<CanvasGroup>();
        hintCanvas.alpha = 0;
        ShowHints();
    }

    private void ShowHints() {
        StopAllCoroutines();
        StartCoroutine(SmoothShowHint());
    }

    private void HideHints() {
        StopAllCoroutines();
        StartCoroutine(SmoothHideHint());
    }

    IEnumerator SmoothShowHint() {
        while (hintCanvas.alpha < 1f) {
            hintCanvas.alpha += smoothness;
            yield return null;
        }
        yield return new WaitForSeconds(timeShowingHint);
        HideHints();
    }

    IEnumerator SmoothHideHint() {
        while (hintCanvas.alpha > 0) {
            hintCanvas.alpha -= smoothness;
            yield return null;
        }
    }

}
