using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro ;

public class ScoreText : MonoBehaviour
{
    public static int score;
    public TMP_Text scoreText ;

    void Start()
    {
        score = 0 ;
    }

    void Update()
    {
        scoreText.text = $"Score: {score}" ;
    }
}
