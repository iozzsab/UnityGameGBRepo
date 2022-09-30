using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public  GameObject Player;

    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused )
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
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.visible.Equals(false);

        Player.GetComponent<FirstPersonController>().enabled = true;
        Player.GetComponent<Shoot>().enabled = true;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.visible.Equals(true);

        Player.GetComponent<FirstPersonController>().enabled = false;
        Player.GetComponent<Shoot>().enabled = false;


    }
    public void LoadMenu()
    {
        Debug.Log("Загружаем меню");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
    public void QuitGame()
    {
        Debug.Log("Выходим из игры");
        Application.Quit();

    }
}

