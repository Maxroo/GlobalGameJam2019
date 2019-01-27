using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyMember : MonoBehaviour
{

    //Stats
    [SerializeField] string characterName;
    [Range(0,1)][SerializeField] float mood = 0.9f;
    [Range(0, 1)] [SerializeField] float loyalty = 1f;
    [Range(0, 1)] [SerializeField] float relationship = 0.25f;
    private Slider[] stats;

    //Status Variables
    private bool isRobot;
    private bool hasLeft;
    private bool isDead;

    private void Start() {
        stats = GetComponentsInChildren<Slider>();
        ChangeStats(mood, loyalty, relationship);
    }

    public void ChangeStats(float mood, float loyalty, float relationship) {
        foreach (var stat in stats) {
            if (stat.name == "Mood") {

                stat.value = mood;

            }
            if (stat.name == "Loyalty") {

                stat.value = loyalty;

            }
            if (stat.name == "Relationship") {

                stat.value = relationship;

            }
        }
    }

    private void Update() {
        ChangeStats(mood, loyalty, relationship);
    }
}
