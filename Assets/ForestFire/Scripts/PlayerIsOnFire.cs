using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerIsOnFire : MonoBehaviour
{
 //   public healthBar HealthBar;

    public BoxCollider FireArea;

 //   public int maxHealth = 100;                                 //sets player max health
 //   public int currentHealth;                                   //creates a value for current player health

    //void Start()
    //{
    //    currentHealth = maxHealth;                              //sets current health value
    //    HealthBar.setMaxHealth(maxHealth);                      //  
    //}

    private void OnTriggerEnter(Collider other)
    {
 //       TakeDamage(10);
  //      Debug.Log(currentHealth);
        Debug.Log("Burns");     
    }
    //void TakeDamage(int damage)
    //{
    //    currentHealth -= damage;
    //    HealthBar.SetHealth(currentHealth);
    //}
}
