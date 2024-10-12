using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
        /*Trong ngoac se la canh tiep theo sau khi nhan nut play*/
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
