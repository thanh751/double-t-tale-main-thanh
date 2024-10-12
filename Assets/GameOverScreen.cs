using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public void Setup(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = Mathf.FloorToInt(score).ToString("D5");
    }

    public void RestartButton()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }

    public void HomeButton()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
