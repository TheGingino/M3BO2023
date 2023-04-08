using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to a GameObject with an Animator component attached.
//For this example, create parameters in the Animator and name them “Crouch” and “Jump”
//Apply these parameters to your transitions between states

//This script allows you to trigger an Animator parameter and reset the other that could possibly still be active. Press the up and down arrow keys to do this.

public class animation : MonoBehaviour
{
    //Maak een variabele aan voor je animator component
    private Animator ani;
    private float speed = 1;

    void Start()
    {
        //Pak het animator component en sla die op in de variabele
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        speed = -Input.GetAxis("Horizontal");
    }

    // nutteloos in dit project
}