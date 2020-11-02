using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StillInTheFire : MonoBehaviour
{
    public GameObject DamageColor;

    public BoxCollider FireArea;

    public bool isTriggerActive;

    void Awake()
    {
        DamageColor = GameObject.Find("DamageImage");
        if (DamageColor)
            Debug.Log("Image Found");
        else
            Debug.Log("Image not found");
    }

    private void OnTriggerEnter(Collider other)
    {
        isTriggerActive = true;
        DamageColor.transform.Translate(0.0f, 0.0f, +4.0f);
        ReturnPosition();
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    isTriggerActive = true;
    //    DamageColor.transform.Translate(0.0f, 0.0f, +4.0f);
    //    ReturnPosition();
    //}

    void ReturnPosition()
    {
        DamageColor.transform.Translate(0.0f, 0.0f, -4.0f);
        StartCoroutine(ColorPause());
    }

    void DamageReceived()
    {
        isTriggerActive = false;
    }

    IEnumerator ColorPause()
    {
        if (isTriggerActive)
        {
            Debug.Log("Coroutine working...");
            yield return new WaitForSeconds(0.2f);
            DamageReceived();
        }
        else
        {
            DamageReceived();
        }
    }
}
