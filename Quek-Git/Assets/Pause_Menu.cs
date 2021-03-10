using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause_Menu : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Script;
    public GameObject PostProcessing;
    public GameObject PauseProcessing;
    public AudioSource Music;
    public float Volume;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (GameIsPaused)
            {
                Resume();
                Music.volume = Volume;
            }
            else
            {
                Pause();
                Music.volume = Volume / 10;
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Script.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PostProcessing.SetActive(true);
        PauseProcessing.SetActive(false);
        Music.volume = Volume;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Script.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PostProcessing.SetActive(false);
        PauseProcessing.SetActive(true);
       
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
