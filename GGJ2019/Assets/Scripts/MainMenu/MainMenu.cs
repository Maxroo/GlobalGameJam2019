using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayClicked()
    {
        AudioManager.instance.PlayClickSoundEffect();
        SceneManager.LoadScene("OpeningScene");
    }

    public void onCreditClicked()
    {
        AudioManager.instance.PlayClickSoundEffect();
        SceneManager.LoadScene("Credit");
    }
}
