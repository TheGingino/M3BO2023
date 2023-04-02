using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class StandardMovementScript : MonoBehaviour
{   
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightShift) && Input.GetMouseButtonDown(0)) { }

        Debug.Log("Cube staat op" + transform.position);
    }
}