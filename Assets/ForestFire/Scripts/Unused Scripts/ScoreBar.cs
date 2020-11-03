using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public ScoreBar scoreBar;

    public Slider scoreSlider;
    public Gradient Gradient;
    public Image fill;

    public int maxScore = 200;                                 //sets player max health
    public int currentScore;                                   //creates a value for current player health

    public void setStartScore()
    {
        scoreSlider.maxValue = maxScore;
        scoreSlider.value = 0;
        fill.color = Gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        scoreSlider.value = health;
        fill.color = Gradient.Evaluate(scoreSlider.normalizedValue);
    }
}
