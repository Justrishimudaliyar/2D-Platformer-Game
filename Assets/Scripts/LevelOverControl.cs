using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverControl : MonoBehaviour

{
    public int Level;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<PlayerController>())
        {
            //Debug.Log("Level Complete");
            SceneManager.LoadScene(Level);
        }
    }
}

