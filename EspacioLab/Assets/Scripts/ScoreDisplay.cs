using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreDisplay : MonoBehaviour
{

    TMPro.TextMeshProUGUI scoreText;

    
    Score score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TMPro.TextMeshProUGUI>();
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.GetScore().ToString();
    }
}
