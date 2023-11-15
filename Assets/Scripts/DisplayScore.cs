using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private GameObject scoreManagerObject;
    private Score scoreScipt;
    public Text scoreText;
    private string scoreToDisplay;
    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreScipt = scoreManagerObject.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreToDisplay = "Score: " + scoreScipt.score + "";
        scoreText.text = scoreToDisplay;
    }
}
