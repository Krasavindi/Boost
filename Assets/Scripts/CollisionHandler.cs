using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float timeBeforeload = 2f;
    [SerializeField] AudioSource explosionSound;
    [SerializeField] AudioSource successSound;
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem crushParticle;
    bool isTransitioning = false;
    bool collisionDisabled = false;

    private void Start() 
    {
        successParticle.Stop();
        crushParticle.Stop();
    }
    void Update()
    {
        RespondToKey();
    }

    private void RespondToKey()
    {
       if(Input.GetKeyDown(KeyCode.L))
        {
            LoadNextScene();
        } 
       else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }  
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning || collisionDisabled)
        {
            return;
        }

        switch(other.gameObject.tag)
        {
            case "Friendly":
            return;

            case "Fuel":
            FindObjectOfType<FuelTimer>().Plus(10);
            Destroy(other.gameObject);
            break;

            case "Finish":
            Landing();
            break;

            default:
            Crush();
            break;
        } 
    }
    public void Crush()
    {
        FindObjectOfType<Movement>().StopThrusting();
        FindObjectOfType<GameSession>().DamageDealer(1);
        crushParticle.Play();
        explosionSound.Play();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadCurrentScene", timeBeforeload);
    }
    private void Landing()
    {
        FindObjectOfType<Movement>().StopThrusting();
        successParticle.Play();
        successSound.Play();
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextScene", timeBeforeload);
    }
    private void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex); 
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    private void LoadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
