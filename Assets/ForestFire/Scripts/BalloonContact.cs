using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class BalloonContact : MonoBehaviour
{
    public BoxCollider BalloonArea;                                 //creates box collider object
    public GameObject Balloon;                                      //creates gameobject
    public TMPro.TMP_Text playerScore;                              //creates text object

    public int maxPlayerScore, currentPlayerScore, pointValue;      //creates various integers
    public float maxSpeed = 5f;                                     //creates and defines float for max speed
    public float acceleration = 0.05f;                              //creates and defines float for acceleration
    public float balloonY;                                          //creates float for balloon y axis tracker
    public bool balloonHit;                                         //creates bool for if the balloon has been hit

    private void Awake()                    
    {
        playerScore = FindObjectOfType<TMPro.TMP_Text>();           //finds textMeshPro object and defines playerScore
        //if (playerScore)
        //    Debug.Log("Score text is found!!");                     //debug's whether it is found or not
        //else
        //    Debug.Log("Score text not found, try again!!");
    }

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerScore = 0;                                     //defines current player score
        maxPlayerScore = 200;                                       //defines max score
        balloonHit = false;                                         //sets balloon hit to not true
        playerScore.text = "Your score is: 0";                      //sets initial score to TMP
    }

    // Update is called once per frame
    void Update()
    {
        balloonY = Balloon.transform.position.y;                                    //defines balloonY as gameObjects Y location

        if (balloonHit == true)                                                     //asks whether balloon has been hit
        {
            Balloon.transform.Translate(0, acceleration * Time.deltaTime, 0);       //if so, change the gameObject location
            if (acceleration < maxSpeed)                                            //asks if acceleration is less than maxSpeed
            {
                acceleration += 0.05f;                                              //if so, increase acceleration
            }
            //Debug.Log(balloonY);                                                  //debug log to check balloonY value
            if (balloonY >= 100f)                                                   //if balloonY is greater than or equal to 100
            {
                balloonHit = false;                                                 //set balloon hit to false
                acceleration = 0;                                                   //set new acceleration value
                maxSpeed = 0;                                                       //set new max speed value (these values will result in object no longer moving)
                Balloon.transform.localScale -= new Vector3(0.125f, 5f, 0.125f);    //scale the balloon object to be 0
                //Debug.Log("Balloon is destroyed");                                //debug log to confirm balloon "destroyed"

            }
        }

        if (currentPlayerScore == maxPlayerScore)                   //if the player score is equal to the max available score
        {
            SceneManager.LoadScene(sceneName: "Win");               //change scene to scene with name "win"
        }
    }

    void GivePoints()
    {
        pointValue = 10;                                            //defines the value of a scoring point
        currentPlayerScore += pointValue;                           //will add the point value to players current score
        balloonHit = true;                                          //sets balloon hit to true
        //Debug.Log("this script is doing something");              //debug log to check function working
    }

    private void OnTriggerEnter(Collider other)
    {        
        GivePoints();                                                   //activates GivePoints function
        Debug.Log("Player score is" + currentPlayerScore);              //debug logs current player score
        playerScore.text = "Your score is: " + currentPlayerScore;      //sets text mesh to "Your score is:" along with the new current score
        //Debug.Log("Hit Balloon");                                     //debug check to ensure on trigger enter working correctly


    }

}
