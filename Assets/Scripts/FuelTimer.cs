using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FuelTimer : MonoBehaviour
{
    [SerializeField] float levelTime = 5;
    
    
    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        IsOver();
    }
    public bool TimeIsFinished()
    {
        if(Time.timeSinceLevelLoad >= levelTime)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void IsOver()
    {
        if(TimeIsFinished())
        {
           SceneManager.LoadScene("GameOver");
        }
        else{ return;} 
    }
    public void Plus(float addFuel)
    {
        levelTime += addFuel;
    }
    
}
