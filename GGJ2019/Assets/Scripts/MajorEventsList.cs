using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MajorEventsList : MonoBehaviour
{
    public static MajorEventsList instance;
    public string[] majorEventNames;

    private void Awake() {
        if(instance != null){
            Destroy(this);
        }
        instance = this;
    }
   
}
