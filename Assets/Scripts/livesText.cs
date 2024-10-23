using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class livesText : MonoBehaviour
{
    
    TextMeshProUGUI lives;
    int rocketLives;
    // Start is called before the first frame update
    void Start()
    {
        
        rocketLives = FindObjectOfType<GameSession>().GetLives();
    }

    // Update is called once per frame
    void Update()
    {
        lives = GetComponent<TextMeshProUGUI>();
        
        lives.text = rocketLives.ToString();
    }
}
