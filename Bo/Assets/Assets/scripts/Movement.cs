using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //movement
    public float speed = 2f;
    float min_speed = 2f;
    float max_speed = 4f;

    float rotationSpeed = 100f;
    Vector3 angles;


    //NewsPaper
    public GameObject NewsPaper;
    const int max_amount = 10;
    int current_Amount = 10;
    public GameObject spawnPoint;


    // Start is called before the first frame update
    private void Start()
    {
        angles = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        

        //key indrukken
        if (Input.GetKey(KeyCode.W))
        {
            speed = max_speed;
        }
        //key loslaten
        if (Input.GetKeyUp(KeyCode.W))
        {
            speed = min_speed;
        }

        //je draait naar links
        if (Input.GetKey(KeyCode.A))//left arrow key
        {
            //{
            //Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);
            //transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
            //}
            angles.y -= rotationSpeed * Time.deltaTime;
            angles.y = Mathf.Clamp(angles.y, -30, 30);
        }

        //je draait naar rechts
        if (Input.GetKey(KeyCode.D))//right arrow key
        {
            angles.y += rotationSpeed * Time.deltaTime;
            angles.y = Mathf.Clamp(angles.y, -30, 30);
        }
        transform.rotation = Quaternion.Euler(angles);

        //brieg gooien script
        if(Input.GetKeyDown(KeyCode.Space))//als je genoeg hebt
        {
            //check eerst of je genoeg hebt
            if(current_Amount > 0)
            {
                GameObject news = Instantiate(NewsPaper,spawnPoint.transform.position, spawnPoint.transform.rotation);
                Rigidbody rb= news.GetComponent<Rigidbody>();
                rb.AddForce(spawnPoint.transform.forward, ForceMode.Impulse);
            }

            //spawn 
        }
    }
}