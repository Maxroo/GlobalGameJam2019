using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    private Coroutine TextCoroutine;

    private int currentPhase = 0;

    private float time;

    
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        showGameOver();
    }

    void showGameOver()
    {

        switch(currentPhase)
        {
            case 0:
            canvasGroup.alpha += 0.01f;
            if(canvasGroup.alpha == 1)
            {
                currentPhase ++;
            }
            break;
            
            case 1:
            canvasGroup.alpha -= 0.01f;
            if(canvasGroup.alpha == 0)
            {
                currentPhase ++;
            }
            break;

            case 2:
            if(time > 5)
            {
                print("LoadMainMenu");
                SceneManager.LoadScene("MainMenu");
                currentPhase ++;
            }
            break;
        }
        
    }

    
}
