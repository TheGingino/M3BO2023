using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public GameObject Canvas;
    public TextMeshProUGUI scoreText;
    public int score = 0;
    public int maxScore;

    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        score= 0;
    }

    // Update is called once per frame
    public void AddPoint()
    {
        score += 100;
        scoreText.text = score.ToString();
        Canvas.GetComponent<TextMeshProUGUI>().text = "Score: " + scoreText.text; //zet de punten op het eindscherm
    }

    public void UpdatePoint()
    {
        scoreText.text = score.ToString();
        Canvas.GetComponent<TextMeshProUGUI>().text = scoreText.text; // zet de tekst op het eindscherm
    }
}
