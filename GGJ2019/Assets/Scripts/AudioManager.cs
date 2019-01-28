using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;

    AudioClip neutralMusic;
    AudioClip possitiveMusic;
    AudioClip negativeMusic;
    AudioClip intenseMusic;

    
    AudioSource audioSourceRef;

    private void Awake() {

       if(instance != null){
           instance = this;
       }
       instance = this;
   }

   public void PlayNeutralMusic(){
       if(audioSourceRef.clip != neutralMusic){
           audioSourceRef.clip = neutralMusic;
           audioSourceRef.Play();
       }
       
   }

   public void PlayPositiveMusic(){
       if(audioSourceRef.clip != possitiveMusic){
           audioSourceRef.clip = possitiveMusic;
           audioSourceRef.Play();
       }
   }

   public void PlayNegativeMusic(){
       if(audioSourceRef.clip != negativeMusic){
           audioSourceRef.clip = negativeMusic;
           audioSourceRef.Play();
       }
   }

   public void PlayIntenseMusic(){
       if(audioSourceRef.clip != intenseMusic){
           audioSourceRef.clip = intenseMusic;
           audioSourceRef.Play();
       }
   }
}
