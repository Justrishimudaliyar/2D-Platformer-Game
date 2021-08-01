using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Button buttonRestart;
    
    private void Awake()
    {
        buttonRestart.onClick.AddListener(Restart);
    }
    public void PlayerDied()
    {
        Invoke("PlayerDied", 2.0f);
        gameObject.SetActive(true);
    }

    public void Restart()
    {
        
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    
}
