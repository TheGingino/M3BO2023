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
    //muziek
    public AudioSource AudioSource;
    public AudioSource Play;

    //movement
    public float speed = 4f;
    float min_speed = 4f;
    float max_speed = 6f;

    float rotationSpeed = 100f;
    Vector3 angles;


    //NewsPaper
    public GameObject NewsPaper;
    public GameObject spawnPoint;
    float force = 10f;

    //Timer
    float delay = 1.0f;
    private float timer = 0.0f;

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
        AudioSource.Play();//muziek player
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;//laat het object automatisch al bewegen
        

        //key indrukken
        if (Input.GetKey(KeyCode.W))
        {
            speed = max_speed; //als je op W drukt ga je sneller
        }
        //key loslaten
        if (Input.GetKeyUp(KeyCode.W))
        {
            speed = min_speed;//je gaat weer naar het min speed
        }

        //je draait naar links
        if (Input.GetKey(KeyCode.A))//left arrow key
        {
            angles.y -= rotationSpeed * Time.deltaTime;
            angles.y = Mathf.Clamp(angles.y, -30, 30);//geeft een max rotation waarde zodat het niet helemaal rond kan draaien
        }

        //je draait naar rechts
        if (Input.GetKey(KeyCode.D))//right arrow key
        {
            angles.y += rotationSpeed * Time.deltaTime;
            angles.y = Mathf.Clamp(angles.y, -30, 30);//geeft een max rotation waarde zodat het niet helemaal rond kan draaien
        }
        transform.rotation = Quaternion.Euler(angles);

        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))//als je genoeg hebt
        {
            if(timer > delay)
            {
                Shoot();
                timer = 0.0f;
            }
        }
    }

    public void Shoot()
    {
        //krant gooien
            
        GameObject news = Instantiate(NewsPaper,spawnPoint.transform.position, spawnPoint.transform.rotation);
        Rigidbody rb= news.GetComponent<Rigidbody>();
        rb.AddForce(-spawnPoint.transform.right * force, ForceMode.Impulse);
        rb.AddTorque(new Vector3(0, UnityEngine. Random.Range(0,150), 0)); //door dit kan je een object clonen en gooien naar links
           
    }
    //collision voor de obstakels en Health system
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("trap"))
        {
            GameManager.Instance.LoseLive(this);
            col.gameObject.SetActive(false);
            TakeDamage(1); // geeft damage als je een trap object raakt
        }
    }

    //health system dmg mechanic
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        Play.Play(); // zet de healthbar actief met de hoeveelheid hp in een bar
    }
}