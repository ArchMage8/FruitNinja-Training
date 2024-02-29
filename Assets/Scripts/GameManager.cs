using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;


public class GameManager : MonoBehaviour
{
    [SerializeField] private float Score = 0f;
    [SerializeField] private float Duration = 100f;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;


    public void Update()
    {
        Duration -= Time.deltaTime;
        TimeText.text = Mathf.Round(Duration).ToString();
        ScoreText.text = Score.ToString();

        if(Duration <= 0)
        {

            Time.timeScale = 0;
            Debug.Log("Game ended");
        }
    }

    public void IncreaseScore(int increase)
    {
        Score += increase;
    }

    public void DecreaseScore(int decrease)
    {
        Score = Mathf.Max(0, Score - decrease);
    }

    public void IncreaseTime(int increase) 
    { 
        Duration += increase;
    }

    public void DecreaseTime(int decrease)
    {
        Duration -= decrease;
    }
}
