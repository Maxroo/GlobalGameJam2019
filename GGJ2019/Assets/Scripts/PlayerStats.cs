using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Range(0, 100)] [SerializeField] int mood = 50;
    [Range(0, 100)] [SerializeField] int charisma = 50;
    [Range(0, 100)] [SerializeField] int knowledge = 50;
    [Range(0, 100)] [SerializeField] int energy = 50;

    private Slider[] stats;
    private CanvasGroup canvasGroup;
    private float canvasFadeStep = 0.02f;
    private bool nextDayClicked;

    private void Start() {
        stats = GetComponentsInChildren<Slider>();
        ChangePlayerStats( PlayerStatsManager.instance.mood, PlayerStatsManager.instance.energy);
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
    }

    public void ChangePlayerStats(float mood, float energy) {
        foreach (var stat in stats) {

            if (stat.name == "Mood") {

                stat.value = mood / 100;

            } if (stat.name == "Charisma") {

                stat.value = charisma / 100;

            } if (stat.name == "Knowledge") {

                stat.value = knowledge / 100;

            } if(stat.name == "Energy") {

                stat.value = energy / 100;

            }
        }
    }

    private void Update() {
        ChangePlayerStats(PlayerStatsManager.instance.mood,  PlayerStatsManager.instance.energy);
    }

    public void ShowPlayerStats() {
        StopAllCoroutines();
        StartCoroutine(SmoothShow());
    }

    public void HidePlayerStats() {
        StopAllCoroutines();
        StartCoroutine(SmoothHide());
    }

    IEnumerator SmoothShow() {
        while (canvasGroup.alpha < 1f) {
            canvasGroup.alpha += canvasFadeStep;
            yield return null;
        }
    }

    IEnumerator SmoothHide() {
        while (canvasGroup.alpha > 0) {
            canvasGroup.alpha -= canvasFadeStep;
            yield return null;
        }
    }
}
