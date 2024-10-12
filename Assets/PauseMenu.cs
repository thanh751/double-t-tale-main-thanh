using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseBackground;
    public static bool isPause=false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }
    public void PauseGame()
    {
        PauseBackground.SetActive(true);
        Time.timeScale = 0f;
        //Lam cho thoi gian va cac canh dung lai 
        isPause = true;
    }
    public void ResumeGame()
    {
        PauseBackground.SetActive(false);
        Time.timeScale = 1f;
        //Thoi gian va canh tiep tuc chay 
        isPause = false;
    }
    public void Volume(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0f;
        }
        else
        {
            AudioListener.volume = 1f;
        }
    }
    public void BackMainMenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
