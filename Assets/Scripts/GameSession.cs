using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] int lives = 3;
    
    private void Awake() 
    {
        int count = FindObjectsOfType<GameSession>().Length;
        if(count > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if(lives == 0)
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    public void DamageDealer(int damage)
    {
        lives -= damage;
    }
    public int GetLives(){
        return lives;
    }
   
}
