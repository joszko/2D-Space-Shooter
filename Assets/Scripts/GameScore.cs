using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{

    Text scoreTextUI;
    
    int score;
    string scoreStr;

    public int Score
    {

        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScore();
        }
    }

    // Use this for initialization
    void Start()
    {
        scoreTextUI = GetComponent<Text>();
        
    }

    void UpdateScore()
    {
        
        scoreStr = string.Format("{0:000000}", score);
        scoreTextUI.text = scoreStr;
    }

}
