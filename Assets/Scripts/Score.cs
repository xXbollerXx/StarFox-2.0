using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text score;
    private float timer;
    public int bonus;
    private int player_score;
    private int point;
    public float bonus_timer;
   
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        point = 1;
        bonus = 1;
        bonus_timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer>= 1)
        {
            player_score += point * bonus;
            timer = 0;
        }
        score.text = "Score: " + player_score;

        bonus_timer -= Time.deltaTime;

        if (bonus_timer <= 0)
        {
      
            bonus = 1;
        }
    }

     public void SetBonus(int nb, float bt)
    {
        bonus = nb;
        bonus_timer = bt;
    }
}
