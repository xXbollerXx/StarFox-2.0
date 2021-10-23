using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text nearMissText;
    public bool congrates;
    public float scoreAmount = 0f;
    static public float intervalAmount = 100f;

    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score " + PlayerPrefs.GetFloat("HighScore", 0);
        nearMissText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score " + (int)scoreAmount;
        scoreAmount += (intervalAmount * Time.deltaTime) / 10f;

        if (scoreAmount > PlayerPrefs.GetFloat("HighScore", 0))
        {
            PlayerPrefs.SetFloat("HighScore", (int)scoreAmount);
            highScoreText.text = "High Score " + (int)scoreAmount;
        }
    }

    public void reset()
    {
        PlayerPrefs.SetFloat("HighScore", 0);
    }

    public void nearMiss()
    {
        nearMissText.text = "Nice Dodge!";
        scoreAmount += 500f;
        Invoke("cleanText", 1.5f);
    }
    void cleanText()
    {
        nearMissText.text = " ";
    }
}
