using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverControl : MonoBehaviour

{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Debug.Log("Level Complete");
            LevelManager.Instance.MarkCurrentLevelComplete();
        }
    }
}

