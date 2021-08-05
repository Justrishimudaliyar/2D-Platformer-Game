using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFailing : MonoBehaviour
{
    public GameOverController LevelOverObject;
   private void OnTriggerEnter2D(Collider2D collision)
   {
      if (collision.gameObject.GetComponent<PlayerController>() != null)
      {
            LevelOverObject.PlayerDied();
      }   
   }
}
