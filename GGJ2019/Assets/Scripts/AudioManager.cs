using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioManager instance;

    public AudioClip neutralMusic;
    public AudioClip possitiveMusic;
    public AudioClip negativeMusic;

    public AudioClip intenseMusic;

    public AudioClip clickingSFX;
    public AudioClip positiveSFX;
    public AudioClip negativeSFX;

    
    public AudioSource audioSourceRef;
    public AudioSource audioSFXRef;

    private void Awake() {

       if(instance != null){
           instance = this;
       }
       instance = this;
   }


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        PlayNeutralMusic();
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

   public void PlayClickSoundEffect(){      
       if(!audioSFXRef.isPlaying){
        audioSFXRef.PlayOneShot(clickingSFX);
       }
   }
    public void PlayPositiveSoundEffect(){      
       if(!audioSFXRef.isPlaying){
        audioSFXRef.PlayOneShot(positiveSFX);
       }
   } public void PlayNegativeSoundEffect(){      
       if(!audioSFXRef.isPlaying){
        audioSFXRef.PlayOneShot(negativeSFX);
       }
   }
}
