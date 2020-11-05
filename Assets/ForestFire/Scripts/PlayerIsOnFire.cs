using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;
using UnityEngine.PlayerLoop;

public class PlayerIsOnFire : MonoBehaviour
{
    public healthBar HealthBar;                             //creates healthbar object relating to healthbar script

    public BoxCollider FireArea;                            //creates box collider for the area of the fire damage effect

    private float damageTime = 3f;                          //sets damage timer value to 3, which will be 3 seconds      
    private float timer = 0f;                               //sets timer value to zero

    public bool inFire = false;                             //creates bool to see if player if still in the fire    


    private void Awake()
    {
        HealthBar = FindObjectOfType<healthBar>();          //finds object within scene as defined by healthbar
        //if (HealthBar)                                      //debugs whether it is discovered or not
        //    Debug.Log("Health bar is found!!");
        //else
        //    Debug.Log("Not found, try again!!");
    }


void Update()
    {
        if (inFire)                                 //checks if in fire is true
        {
            if (damageTime > timer)                 //if so, and damage time is greater than timer value
            {
                timer += Time.deltaTime;            //add time to timer value
            }
            else
            {       
                HealthBar.TakeDamage();             //if not, activate take damage function on healthbar script
                timer = 0f;                         //reset timer value to zero
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0f;                                 //ensures timer value is zero on entry to collider
        inFire = true;                              //sets inFire bool to true, which will allow the timer to begin
        //Debug.Log("Collider entered");              //debug statement to confirm collider working correctly 
    }

    private void OnTriggerExit(Collider other)
    {
        timer = 0f;                                 //ensures timer value returns to zero on exit of collider
        inFire = false;                             //sets inFire bool to false, deactivating timer
    }
}
