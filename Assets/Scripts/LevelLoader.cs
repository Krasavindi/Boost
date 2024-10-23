using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    int currentSceneIndex;
    
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // if(currentSceneIndex == 0)
        // {
        //     StartCoroutine (WaitForSeconds());
        // }
    }
    
    void Update()
    {

    }
    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        LoadNextScene();
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadScene1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadOptions()
    {
        SceneManager.LoadScene("Option Screen");
    }
    
}
