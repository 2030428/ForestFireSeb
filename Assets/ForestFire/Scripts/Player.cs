using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;


public class Player : MonoBehaviour
{
  //  public ForestFireCell.State fireCell;
    public GameObject player;                                   //declares player object
    public GameObject FireCell;                                 //
  //  public BoxCollider FireDetect;

    public int maxHealth = 100;                                 //sets player max health
    public int currentHealth;                                   //creates a value for current player health
    public float playerX, playerY, playerZ;                     //creates values for player positions on x, y, z axis
    public int playerXint, playerYint, playerZint;              //creates values for player positions on x, y, z axis as whole numers
    public float fireX, fireY, fireZ;                           //creates values for fire positions on x, y, z axis
    public int fireXint, fireYint, fireZint;                    //creates values for fire positions on x, y, z axis as whole numbers

    public healthBar HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;                              //sets current health value
        HealthBar.setMaxHealth(maxHealth);                      //
    }

    // Update is called once per frame
    void Update()
    {
        PlayerLocation();                                       //calls player location void, find the current player location
      //  FindingFireCells();
       
        if (playerXint == fireXint)                             //checks if player x coordinate is the same as fire x coordinate
        {
            if (playerYint == fireYint)                         //checks if player y coordinate is the same as fire y coordinate
            {
                if (playerZint == fireZint)                     //checks if player z coordinate is the same as fire z coordinate
                {
                    TakeDamage(10);                             //call takeDamage function, to remove 10 health
                }
            }
        }
    }

    void PlayerLocation()
    {
        playerX = player.transform.position.x;                  //finds player x coordinate and assigns as a float
        playerY = player.transform.position.y;                  //finds player y coordinate and assigns as a float
        playerZ = player.transform.position.z;                  //finds player z coordinate and assigns as a float

        playerXint = (int)Math.Round(playerX);                  //rounds player x coordinate float to nearest integer and assigns
        playerYint = (int)Math.Round(playerY);                  //rounds player y coordinate float to nearest integer and assigns
        playerZint = (int)Math.Round(playerZ);                  //rounds player z coordinate float to nearest integer and assigns

        //Debug.Log("Player X position is " + playerXint);        
        //Debug.Log("Player Y position is " + playerYint);
        //Debug.Log("Player Z position is " + playerZint);
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeDamage(10);
    }


void TakeDamage(int damage)
    {
        currentHealth -= damage;
        HealthBar.SetHealth(currentHealth);
    }

        //void FindingFireCells()
    //{
    //  //  if (FireCell = ForestFireCell.State.Alight)

    //    //   if (fireCell == ForestFireCell.State.Alight)
    //    {
    //        fireX = FireCell.transform.position.x;
    //        fireY = FireCell.transform.position.y;
    //        fireZ = FireCell.transform.position.z;

    //        fireXint = (int)Math.Round(fireX);
    //        fireYint = (int)Math.Round(fireY);
    //        fireZint = (int)Math.Round(fireZ);

    //        Debug.Log("Fire X location is " + fireXint);
    //        Debug.Log("Fire Y location is " + fireYint);
    //        Debug.Log("Fire Z location is " + fireZint);
    //    }
    //}


}

