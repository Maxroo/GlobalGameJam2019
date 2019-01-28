using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FamilyMember : MonoBehaviour
{

    //Stats
    [SerializeField] FamilyCharacter character;
    [Range(0, 100)] [SerializeField] int mood = 50;
    [Range(0, 100)] [SerializeField] int loyalty = 50;
    [Range(0, 100)] [SerializeField] int relationship = 50;
    private Slider[] stats;

    //Status Variables
    private bool isRobot;
    private bool hasLeft;
    private bool isDead;

    private void Start() {
        stats = GetComponentsInChildren<Slider>();
        ChangeCHaracterStats(mood, loyalty, relationship);
    }

    public void ChangeCHaracterStats(float mood, float loyalty, float relationship) {
        foreach (var stat in stats) {
            if (stat.name == "Mood") {

                stat.value = mood / 100;

            }
            if (stat.name == "Loyalty") {

                stat.value = loyalty / 100;

            }
            if (stat.name == "Relationship") {

                stat.value = relationship / 100;

            }
        }
    }

    private void Update() {
        ChangeCHaracterStats(character.mood, character.loyalty, character.relationship);
    }
}
