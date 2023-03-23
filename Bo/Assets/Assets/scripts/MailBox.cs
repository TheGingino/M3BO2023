using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public GameObject newsPaper;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("NewsPaper"))
        {
            //score systeem
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
