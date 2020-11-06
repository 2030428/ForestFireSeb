using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class ScoreTally : MonoBehaviour
{
    public int maxPlayerScore, currentPlayerScore, pointValue;      //creates various integers

    public TMPro.TMP_Text playerScore;                              //creates text object

    public void Awake()
    {
        playerScore = FindObjectOfType<TMPro.TMP_Text>();           //finds textMeshPro object and defines playerScore
        //if (playerScore)
        //    Debug.Log("Score text is found!!");                     //debug's whether it is found or not
        //else
        //    Debug.Log("Score text not found, try again!!");
    }

    void Start()
    {
        currentPlayerScore = 0;                                     //defines current player score
        maxPlayerScore = 100;                                       //defines max score
        playerScore.text = "Score: 0";                              //sets initial score to TMP
    }

    void Update()
    {
        if (currentPlayerScore == maxPlayerScore)                   //if the player score is equal to the max available score
        {
            SceneManager.LoadScene(sceneName: "Win");               //change scene to scene with name "win"
        }
    }

    public void GivePoints()
    {
        pointValue = 10;                                            //defines the value of a scoring point
        currentPlayerScore += pointValue;                           //will add the point value to players current score
        playerScore.text = "Score: " + currentPlayerScore;          //sets text mesh to "Score: " along with the new current score
        Debug.Log("Player score is" + currentPlayerScore);          //debug logs current player score
    }
}
