using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;


public class BalloonContact : MonoBehaviour
{
    public ScoreTally score;
    public BoxCollider BalloonArea;                                 //creates box collider object
    public GameObject Balloon;                                      //creates gameobject

    public float maxSpeed = 5f;                                     //creates and defines float for max speed
    public float acceleration = 0.05f;                              //creates and defines float for acceleration
    public float balloonY;                                          //creates float for balloon y axis tracker
    public bool balloonHit = false;                                 //creates bool for if the balloon has been hit
    public bool hasBeenTriggered = false;                           //creates bool for to see if collider has been triggered previously
    public bool balloonHasScaled = false;                           //creates bool to see if balloon needs to be scaled more

    private void Awake()
    {
        score = FindObjectOfType<ScoreTally>();                     //finds textMeshPro object and defines playerScore
        //if (score)
        //    Debug.Log("Score tally is found!!");                    //debug's whether it is found or not
        //else
        //    Debug.Log("Score tally not found, try again!!");
    }

    void Update()
    {
        balloonY = Balloon.transform.position.y;                                    //defines balloonY as gameObjects Y location

        if (balloonHit)                                                             //asks whether balloon has been hit
        {
            DisableCollider();                                                      //ensures collider is disabled
            Balloon.transform.Translate(0, acceleration * Time.deltaTime, 0);       //if so, change the gameObject location
            if (acceleration < maxSpeed)                                            //asks if acceleration is less than maxSpeed
            {
                acceleration += 0.05f;                                              //if so, increase acceleration
            }
            //Debug.Log(balloonY);                                                  //debug log to check balloonY value

            if (balloonY >= 0.3f)
            {
                DisableCollider();
            }
            if (balloonY >= 50f)                                                    //if balloonY is greater than or equal to 100
            {
                if (balloonHasScaled == false)                                      //checks if balloon has already been scaled
                {
                    DisableCollider();
                    acceleration = 0;                                               //set new acceleration value
                    maxSpeed = 0;                                                   //set new max speed value (these values will result in object no longer moving)                    
                    ScaleBalloon();                                                 //calls scale ballon function
                    //Debug.Log("Balloon is destroyed");                             //debug log to confirm balloon "destroyed"

                }
            }
        }
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (hasBeenTriggered)                                           //checks if bool for has been triggered is true
        {
            DisableCollider();                                          //if so, ensures collider inactive if has been triggered already
        }
        else
        {
            score.GivePoints();                                         // if not, activates GivePoints function
            balloonHit = true;                                          //sets balloon hit to true
            hasBeenTriggered = true;                                    //Sets has been triggered to true
            //Debug.Log("Hit Balloon");                                   //debug check to ensure on trigger enter working correctly
        }
    }
     
    public void OnTriggerExit(Collider other)
    {
        hasBeenTriggered = true;                                        //sets has been triggered to true
        DisableCollider();                                              //calls function for disable collider
    }
    public void DisableCollider()
    {
        BalloonArea.enabled = false;                                    //disables collider so cannot get double score
    }

    public void ScaleBalloon()
    {
        Balloon.transform.localScale -= new Vector3(0.125f, 5f, 0.125f);    //scale the balloon object to be 0
        balloonHasScaled = true;                                            //confirms balloon has been scaled
    }

}
