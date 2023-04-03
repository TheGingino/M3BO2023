using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
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
    float force = 8f;


    //Health
    public int maxHealth = 3;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    private void Start()
    {
        angles = transform.eulerAngles;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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

        //krant gooien script
        if(Input.GetKeyDown(KeyCode.Space))//als je genoeg hebt
        {
            //check eerst of je genoeg hebt
            if(current_Amount > 0)
            {
                GameObject news = Instantiate(NewsPaper,spawnPoint.transform.position, spawnPoint.transform.rotation);
                Rigidbody rb= news.GetComponent<Rigidbody>();
                rb.AddForce(spawnPoint.transform.forward * force, ForceMode.Impulse);
                rb.AddTorque(new Vector3(0, UnityEngine. Random.Range(0,150), 0));
            }
            //spawn
        }


        
    }

    //collision voor de obstakels en Health system
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("trap"))
        {
            GameManager.Instance.LoseLive(this);
            col.gameObject.SetActive(false);
            TakeDamage(1);
        }
    }

    //health system dmg mechanic
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void React()
    {
        transform.position = new Vector3(180, 1.38f, 175);
    }

}

