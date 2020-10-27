using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class Player : MonoBehaviour
{
  //  public ForestFireCell.State fireCell;
    public GameObject player;
    public GameObject FireCell;

    public int maxHealth = 100;
    public int currentHealth;
    public float playerX, playerY, playerZ;
    public int playerXint, playerYint, playerZint;
    public float fireX, fireY, fireZ;
    public int fireXint, fireYint, fireZint;

    public healthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLocation();
      //  FindingFireCells();

        if (playerXint == fireXint)
        {
            if (playerYint == fireYint)
            {
                if (playerZint == fireZint)
                {
                    TakeDamage(10);
                }
            }
        }
    }

    void PlayerLocation()
    {
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        playerZ = player.transform.position.z;

        playerXint = (int)Math.Round(playerX);
        playerYint = (int)Math.Round(playerY);
        playerZint = (int)Math.Round(playerZ);

        Debug.Log("Player X position is " + playerXint);
        Debug.Log("Player Y position is " + playerYint);
        Debug.Log("Player Z position is " + playerZint);
    }

    void FindingFireCells()
    {
      //  if (FireCell = ForestFireCell.State.Alight)

        //   if (fireCell == ForestFireCell.State.Alight)
        {
            fireX = FireCell.transform.position.x;
            fireY = FireCell.transform.position.y;
            fireZ = FireCell.transform.position.z;

            fireXint = (int)Math.Round(fireX);
            fireYint = (int)Math.Round(fireY);
            fireZint = (int)Math.Round(fireZ);

            Debug.Log("Fire X location is " + fireXint);
            Debug.Log("Fire Y location is " + fireYint);
            Debug.Log("Fire Z location is " + fireZint);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }


}

