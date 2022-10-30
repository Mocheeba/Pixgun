using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
   public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

   void Update() 
   {
     if (Input.GetKeyDown(KeyCode.Escape))
     {
        if (gameIsPaused)
        {
            Resume();
        } else

        {
            Pause();
        }
     }
   }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
   

    public void LoadMenu()
    {
        Debug.Log("Loading menu...");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("The game is close");
        Application.Quit();
    }

}
