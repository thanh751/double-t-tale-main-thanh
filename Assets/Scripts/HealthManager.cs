using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public static HealthManager Instance;

    void Awake()
    {
        Instance = this;
        health = 3;
        //Mỗi lần chơi lại thì đều bằng 3 
    }
    void Update()
    {
        foreach (Image img in hearts)
        {
            img.sprite = EmptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = FullHeart;
        }
    }
    public void SetAllHeartsEmpty()
    {
        foreach (Image img in hearts)
        {
            img.sprite = EmptyHeart;
        }
    }
    //void Update()
    //{
    //    for (int i = 0; i < hearts.Length; i++) // Iterate through all hearts
    //    {
    //        if (i < HealthManager.health) // Check if index is less than current health
    //        {
    //            hearts[i].sprite = FullHeart;
    //        }
    //        else
    //        {
    //            hearts[i].sprite = EmptyHeart;
    //        }
    //    }
    //}
}