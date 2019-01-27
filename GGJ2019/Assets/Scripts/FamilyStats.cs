using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamilyStats : MonoBehaviour {

    private bool toggleStatsButton;
    [SerializeField] GameObject[] path;
    private int moveSpeed = 1000;

    public void ToggleFamilyStats() {

        toggleStatsButton = !toggleStatsButton;

        if (toggleStatsButton) {
            ShowFamilyStats();

        } else {
            HideFamilyStats();
        }
    }

    public void ShowFamilyStats() {
        transform.position = Vector2.MoveTowards(
            transform.position,
            path[1].transform.position,
            moveSpeed
            );
    }

    public void HideFamilyStats() {
    transform.position = Vector2.MoveTowards(
        transform.position,
        path[0].transform.position,
        moveSpeed
        );
    }

    
}
