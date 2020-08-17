using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{

    public  int MaxHealth;
    public int CurrentHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < CurrentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < MaxHealth)
            {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
                    }
        }
    }

    public void ResetVar()
    {
        CurrentHealth = MaxHealth;
    }

}
