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

    public GameObject DamageColor;                              //creates gameobject for damage colour effect

    public int maxHealth = 100;                                 //creats and defines player max health
    public int currentHealth, damage;                           //creates integers for current player health and damage amount


    private void Start()
    {
        currentHealth = maxHealth;
        setMaxHealth();
    }

    public void setMaxHealth()
    {
        healthSlider.maxValue = maxHealth;             
        healthSlider.value = currentHealth;
        fill.color = Gradient.Evaluate(1f);
    }

    public void TakeDamage()
    {
        Debug.Log("Player health is " + currentHealth);
        damage = 10;                                                            //sets damage value
        currentHealth -= damage;                                                //removes damage value from currrent health
        healthSlider.value = currentHealth;
        fill.color = Gradient.Evaluate(healthSlider.normalizedValue);
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
