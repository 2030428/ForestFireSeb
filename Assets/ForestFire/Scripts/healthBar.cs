using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public healthBar HealthBar;

    public Slider healthSlider;
    public Gradient Gradient;
    public Image fill;

    public int maxHealth = 100;                                 //sets player max health
    public int currentHealth;                                   //creates a value for current player health

    public void setMaxHealth(int health)
    {
        healthSlider.maxValue = health;
        healthSlider.value = health;
        fill.color = Gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        healthSlider.value = health;
        fill.color = Gradient.Evaluate(healthSlider.normalizedValue);
    }

    //void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    HealthBar.SetHealth(currentHealth);
    //}

}
