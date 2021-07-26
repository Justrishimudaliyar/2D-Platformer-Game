using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int health;
    public int noOfHearts;
    public Image[] hearts;
    public Image[] emptyHearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;
    public PlayerController KillPlayer;

    void Update()
    {

        if (health > noOfHearts)
        {
            health = noOfHearts;
        }

       

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHeart;
            }
            else
                hearts[i].sprite = EmptyHeart;

            if (i < noOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
                hearts[i].enabled = false;
        }
    }

    
    public void healthReduce()
    {
        if (health == 0)
        {
            KillPlayer.KillPlayer();
        }

        else
        {
            health = health - 1;
            Debug.Log("Health reduced");
        }
            
        
    }
}   
