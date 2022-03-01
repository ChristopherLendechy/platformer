using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    // variables for the ui countdown
    private int _totalTime = 100;
    private float _accumulatedTime = 0f;
    
    public TextMeshProUGUI gameText;
    public int score = 0;
    public int coins = 0;
    
    
    private 
    //public int points = 0;

    //public int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        gameText.text = "Score: " + score + " Coins: " + coins +
                        " World 1-1" + " Time: " + _totalTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCountdown();
    }

    public void UpdateText(string element, int value)
    {
        switch (element)
        {
            case "score":
                score += 100;
                gameText.text = "Score: " + score + " Coins: " + coins +
                                " World 1-1" + " Time: " + _totalTime;
                break;
            case "coin":
                coins += 1;
                score += 100;
                gameText.text = "Score: " + score + " Coins: " + coins +
                                " World 1-1" + " Time: " + _totalTime;
                break;
            case "time":
                gameText.text = "Score: " + score + " Coins: " + coins +
                                " World 1-1" + " Time: " + _totalTime;
                break;
            
        }
    }

    public void TimeCountdown()
    {
        _accumulatedTime += Time.deltaTime;

        if (_accumulatedTime > 1f)
        {
            _totalTime -= 1;
            _accumulatedTime = 0f;
            UpdateText("time",_totalTime);
            // Debug.Log($"time is {_totalTime}");
        }

        if (_totalTime == 0)
        {
            Debug.Log("YOU FAILED");
        }
    }

    public void AddScore()
    {
        gameText.text = "Score: " + score + " Coins: " + coins +
                        "World 1-1" + " Time: " + _totalTime;
    }
    public void AddCoin(){}
}
