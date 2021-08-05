using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverControl : MonoBehaviour

{
    public LevelCompleteScripts LevelComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>())
        {

            LevelManager.Instance.MarkCurrentLevelComplete();
            LevelComplete.LevelCompleted();
        }
    }
}

