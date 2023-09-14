using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject[] ui;
    
    

    // Start is called before the first frame update

    public void Setup()
    {
        gameObject[0].SetActive(true);
        ScoreManager.instance.UpdatePoint(); //is voor de punten toevoeging aan het Game Over scherm
        A.Play();
    }
   

    public void gameOver()
    {
        ui[0].SetActive(true);
        ui[1].SetActive(false);
    }

}
