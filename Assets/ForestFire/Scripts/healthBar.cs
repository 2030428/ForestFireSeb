using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class healthBar : MonoBehaviour
{
    
    public Slider healthSlider;                     //creates a new slider called health slider
    public Gradient Gradient;                       //creates a new graident called gradient
    public Image fill;                              //creates a new image called fill

    public GameObject DamageColor;                  //creates gameobject for damage colour effect

    public int maxHealth = 100;                     //creats and defines player max health
    public int currentHealth, damage;               //creates integers for current player health and damage amount


    private void Start()
    {
        currentHealth = maxHealth;                  //sets current health to max available health
        setMaxHealth();                             //activates setMaxHealth function
    }

    public void setMaxHealth()
    {
        healthSlider.maxValue = maxHealth;          //sets max value of slider to be that of max available health
        healthSlider.value = currentHealth;         //sets current value of slider, which in this case is maximum available
        fill.color = Gradient.Evaluate(1f);         //sets the colour of the fill image to be a gradient colour
    }

    public void TakeDamage()
    {
        //Debug.Log("Player health is " + currentHealth);                         //debug log of current player health, to ensure deduction is working correctly
        damage = 10;                                                            //sets damage value
        currentHealth -= damage;                                                //removes damage value from currrent health
        healthSlider.value = currentHealth;                                     //adjusts the healthbar slider value
        fill.color = Gradient.Evaluate(healthSlider.normalizedValue);           //adjusts healthbar gradient colour, if required
        DamageColor.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);      //increases scale of damage colour object
        StartCoroutine(ColorPause());                                           //initiates colour pause coroutine

        if (currentHealth == 0)                                 //if current health is equal to 0
        {
            SceneManager.LoadScene(sceneName: "Dead");          //change scene to scene with name "Dead" 
        }
    }
    
    void HasTakenDamage()
    {       
        DamageColor.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);      //if so, reduces damage colour object back to original scale
        //Debug.Log("Has now taken damage");                                      //debug to check process has completed
    }

    IEnumerator ColorPause()
    {
        //Debug.Log("Coroutine working...");                      //debug statement to check coroutine working
        yield return new WaitForSeconds(0.3f);                  //sets value for to wait before moving on
        HasTakenDamage();                                       //activates has taken damage function
    }

}
