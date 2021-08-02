using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelCompleteScripts : MonoBehaviour
{
    public Button buttonRestart;
    public Button ExitButton;
    public Button NextLevelButton;

    private void Awake()
    {
        buttonRestart.onClick.AddListener(Restart);
        ExitButton.onClick.AddListener(Exit);
        NextLevelButton.onClick.AddListener(NextLevel);
    }
    public void LevelCompleted()
    {
        //Invoke("PlayerDied", 2.0f);
        SoundManager.Instance.PlayMusic(Sounds.LevelComplete);
        gameObject.SetActive(true);
    }

    public void Exit()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
    public void Restart()
    {

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }


}
