using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    public Text scoreText;
    int currentScore;

    void Awake()
    {
        instance = this;
        UpdateUI();

    }

    public void AddScore(int score)
    {
        currentScore +=score;
        UpdateUI();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString("D5");
    }
}
