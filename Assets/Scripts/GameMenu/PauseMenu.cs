using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    /* public AudioMixer audioMixer; */

    public static bool GameIsPaused = false;
    public bool pause;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
        pause = false;  
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        pause = true;
    }

    public void MainMenu()
    {
        GameIsPaused = false;
        pause = true;
        Time.timeScale = 1.0f;
        /* SceneManager.LoadScene("MainMenu"); */
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    /* public void SetVolume(float value)
    {
        audioMixer.SetFloat("MainVolume", value);
    } */
}
