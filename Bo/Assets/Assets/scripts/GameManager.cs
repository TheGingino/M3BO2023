using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public DeathScreen gameManager;

    int lives = 3;

    private bool isDead;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance= this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoseLive(Player p)
    {
        lives--;
        if(lives <= 0 && !isDead)
        {
            isDead = true;
            //laat death zien
            gameManager.gameOver();
            //disable player manager
            p.enabled= false;
            
        }
    }
}
