using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerIsOnFire : MonoBehaviour
{
    public healthBar HealthBar;
    public GameObject DamageColor;

    public BoxCollider FireArea;

    public bool takenAnyDamage, stillInFire = false;
    public int maxHealth = 100;                                 //sets player max health
    public int currentHealth, damage;                                   //creates a value for current player health

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
     //   if (FireArea.gameObject.CompareTag("FireArea"))
        {
            Debug.Log("Burns");
            TakeDamage();
            Debug.Log(currentHealth);
        }
    }

    void TakeDamage()
    { 
        takenAnyDamage = true;
        damage = 10;
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
        DamageColor.transform.localScale += new Vector3(0.2f, 0.2f, 0.2f);
        StartCoroutine(ColorPause());
    }

    IEnumerator ColorPause()
    {
        Debug.Log("Coroutine working...");
        yield return new WaitForSeconds(0.3f);
        takenAnyDamage = true;
        HasTakenDamage();
    }
    void HasTakenDamage()
    {
        if (takenAnyDamage)
        {
            DamageColor.transform.localScale -= new Vector3(0.2f, 0.2f, 0.2f);
            Debug.Log("Has now taken damage");
            takenAnyDamage = false;
        }
    }
    //void OnTriggerStay(Collider other)
    //{
    //    for (int i=10; i > 0; i--)
    //    {
    //        Debug.Log("Collider still in fire");
    //        Thread.Sleep(2000);
    //        TakeDamage();
    //    }
    //}
}
