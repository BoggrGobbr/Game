using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    [SerializeField] public static bool gameIsPaused;
    [SerializeField] GameObject gameUI, pauseMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            if (!gameIsPaused)
                PauseGame(); 
            else
                ResumeGame(); //ALSO REVERTSIZE FOR ALL BUTTONS OR SMTH
        }
    }
    public void PauseGame()
    {
        gameIsPaused = !gameIsPaused;
        gameUI.SetActive(false);
        pauseMenu.SetActive(true);

        Time.timeScale = 0f;
        AudioListener.pause = true;
    }
    public void ResumeGame()
    {
        gameIsPaused = !gameIsPaused;
        gameUI.SetActive(true);
        pauseMenu.SetActive(false);

        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
