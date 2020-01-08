using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    int score;
    Text scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        scoreKeeper = GetComponent<Text>();
        scoreKeeper.text = score.ToString();
    }

    public void scoreHit(int scorePerKill)
    {
        score = score + scorePerKill;
        scoreKeeper.text = score.ToString();
    }

}
