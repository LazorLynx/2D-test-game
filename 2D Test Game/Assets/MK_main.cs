using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnableComponents : MonoBehaviour
{
    private PlayerMovement myLight;


    void Start()
    {
        myLight = GetComponent<PlayerMovement>();
    }


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}