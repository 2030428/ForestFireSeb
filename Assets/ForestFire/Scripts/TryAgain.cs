using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TryAgain : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("try again");
        SceneManager.LoadScene(sceneName: "ForestFire3D");
    }
}
