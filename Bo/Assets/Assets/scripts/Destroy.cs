using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "Newspaper(Clone)")
        {
            Destroy(gameObject, 2); //vernietigt het object na 2 seconden
        }
    }
}
