using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyStats : MonoBehaviour {

    private bool toggleStatsButton;
    [SerializeField] GameObject[] path;
    private int moveSpeed = 50;

    public void ToggleFamilyStats() {

        toggleStatsButton = !toggleStatsButton;

        if (toggleStatsButton) {
            ShowFamilyStats();

        } else {
            HideFamilyStats();
        }
    }

    public void ShowFamilyStats() {
        StopAllCoroutines();
        StartCoroutine(SmoothOpen());
    }

    public void HideFamilyStats() {
        StopAllCoroutines();
        StartCoroutine(SmoothClose());
    }

    IEnumerator SmoothOpen() {
        while(transform.position != path[1].transform.position) {
            transform.position = Vector2.MoveTowards(
            transform.position,
            path[1].transform.position,
            moveSpeed
            );
            yield return null;
        }
    }

    IEnumerator SmoothClose() {
        while (transform.position != path[0].transform.position) {
            transform.position = Vector2.MoveTowards(
            transform.position,
            path[0].transform.position,
            moveSpeed
            );
            yield return null;
        }
    }

    
}
