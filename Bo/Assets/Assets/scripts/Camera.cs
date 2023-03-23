using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Cube;
    private Vector3 offset = new Vector3(0, 5, -7);
    internal static object main;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //offset behind player position
        transform.position = Cube.transform.position + offset;
    }

}
