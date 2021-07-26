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
                hearts[i].enabled = FullHeart;
            }
            else
                hearts[i].enabled = EmptyHeart;

            if (i < noOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
                hearts[i].enabled = false;
        }
    }

}
