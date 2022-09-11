using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject compassUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log(GameIsPaused);
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
        //compassUI.SetActive(true);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        //compassUI.SetActive(false);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }

    public void QuitToMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
