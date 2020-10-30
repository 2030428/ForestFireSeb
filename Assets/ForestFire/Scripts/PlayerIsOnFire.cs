using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerIsOnFire : MonoBehaviour
{
    public healthBar HealthBar;
    public GameObject DamageColor;
    public GameObject player;

    public BoxCollider FireArea;

    public bool takenAnyDamage, ColorPauseActive, DamagePauseActive;
    public int maxHealth = 100;                                 //sets player max health
    public int currentHealth, damage;                                   //creates a value for current player health
    public int playerXint, playerYint, playerZint;

    public float playerX, playerY, playerZ;


    private void Awake()
    {

        DamageColor = GameObject.Find("DamageImage");
        if (DamageColor)
            Debug.Log("Image Found");
        else
            Debug.Log("Image not found");

        HealthBar = FindObjectOfType<healthBar>();
        if (HealthBar)
            Debug.Log("Health bar is found!!");
        else
            Debug.Log("Not found, try again!!");
    }

    void Start()
    {
        currentHealth = maxHealth;                              //sets current health value
        HealthBar.setMaxHealth(maxHealth);                      //   
    }

    void Update()
    {
        if (currentHealth == 0)
        {
            SceneManager.LoadScene(sceneName: "Dead");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Burns");
        TakeDamage();
        Debug.Log(currentHealth);
    }

    void TakeDamage()
    { 
        takenAnyDamage = true;
        damage = 10;
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        DamageColor.transform.Translate(0.0f, 0.0f, +4.0f);
        StartCoroutine(ColorPause());        
    }     

    IEnumerator ColorPause()
    {
        Debug.Log("Coroutine working...");
        yield return new WaitForSeconds(0.1f);
        takenAnyDamage = true;
        HasTakenDamage();
    }
    void HasTakenDamage()
    {
        if (takenAnyDamage)
        {
            DamageColor.transform.Translate(0.0f, 0.0f, -4.0f);
            Debug.Log("Has now taken damage");
            takenAnyDamage = false;
        }
    }
}
