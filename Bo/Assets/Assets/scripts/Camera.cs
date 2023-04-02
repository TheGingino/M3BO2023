using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Cube;
    private Vector3 offset = new Vector3(18, 9, 4);
    internal static object main;

   
    // Update is called once per frame
    void LateUpdate()
    {
        //offset voor een diagonale 3rd person zicht
        transform.position = Cube.transform.position + offset;
    }

}
