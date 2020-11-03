using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.VFX;

public class FindFire : MonoBehaviour
{
    public VisualEffect FireVFX;

    public float fireX, fireY, fireZ;
    public int fireXint, fireYint, fireZint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FindingFire();
    }

    void FindingFire() 
    {
        if (FireVFX.isActiveAndEnabled)

            fireX = FireVFX.transform.position.x;
            fireY = FireVFX.transform.position.y;
            fireZ = FireVFX.transform.position.z;

            fireXint = (int)Math.Round(fireX);
            fireYint = (int)Math.Round(fireY);
            fireZint = (int)Math.Round(fireZ);

            Debug.Log("Fire X location is " + fireXint);
            Debug.Log("Fire Y location is " + fireYint);
            Debug.Log("Fire Z location is " + fireZint);
    }

}
