using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour
{
    private GameObject scoreManagerObject;
    private Score scoreScript;

    void Start()
    {
        scoreManagerObject = GameObject.Find("ScoreManager");
        scoreScript = scoreManagerObject.GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("LevelScene");
            scoreScript.score = 0;
        }
    }
}
