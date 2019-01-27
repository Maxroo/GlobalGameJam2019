using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEventSFX : MonoBehaviour
{

    public int clipID;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateClipID()
    {
     clipID = AudioManager.instance.SFXclipID;   
     playSound();
    }
    void playSound()
    {
        switch(clipID)
        {
            case 1:
            AudioManager.instance.PlayPositiveSoundEffect();            
            break;
            case 2:
            AudioManager.instance.PlayPositiveSoundEffect();
            break;

        }
        
    }
    
    
}
