using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.PlayerLoop;

public class PlayerIsOnFire : MonoBehaviour
{
    public healthBar HealthBar;                                 //creates healthbar object relating to healthbar script

    public BoxCollider FireArea;                                //creates box collider for the area of the fire damage effect

    private float damageTime = 3f;
    private float timer = 0f;

    public bool takenAnyDamage, inFire = false;            //creates bools to see if the player has taken damage and to see if they are still in the fire    


    private void Awake()
    {
        HealthBar = FindObjectOfType<healthBar>();              //finds object within scene as defined by healthbar
        //if (HealthBar)                                          //debugs whether it is discovered or not
        //    Debug.Log("Health bar is found!!");
        //else
        //    Debug.Log("Not found, try again!!");
    }


void Update()
    {
        if (inFire)
        {
            if (damageTime > timer)
            {
                timer += Time.deltaTime;
            }
            else
            {
                HealthBar.TakeDamage();
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0f;
        inFire = true;
        Debug.Log("Collider entered");                               //debug statement of current health 
    }



    private void OnTriggerExit(Collider other)
    {
        timer = 0f;
        inFire = false;
    }
}
