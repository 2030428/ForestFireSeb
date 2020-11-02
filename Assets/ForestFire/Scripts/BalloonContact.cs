using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BalloonContact : MonoBehaviour
{
    public BoxCollider BalloonArea;
    public GameObject Balloon;

    public int maxPlayerScore, currentPlayerScore, pointValue;


    // Start is called before the first frame update
    void Start()
    {
        currentPlayerScore = 0;
        maxPlayerScore = 200;
    }

    // Update is called once per frame
    void Update()
    {
     //   Debug.Log("this script is doing something");

        if (currentPlayerScore == maxPlayerScore)
        {
            SceneManager.LoadScene(sceneName: "Win");
        }
    }

    void GivePoints()
    {
        Debug.Log("this script is doing something");
        pointValue = 10;
        currentPlayerScore += pointValue;
        Destroy(Balloon);
    }

    private void OnTriggerEnter(Collider other)
    {
     //   if (BalloonArea.gameObject.CompareTag("BalloonArea"))
        
            Debug.Log("Hit Balloon");
            GivePoints();
            Debug.Log(currentPlayerScore);
        
    }

}
