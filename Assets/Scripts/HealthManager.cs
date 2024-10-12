using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static int health = 3;
    public Image[] hearts;
    public Sprite FullHeart;
    public  Sprite EmptyHeart;
    public static HealthManager Instance;

    void Awake()
    {
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
}
