using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    public AudioSource A;

    // Start is called before the first frame update
    public void Setup()
    {
        gameObject.SetActive(true);
        ScoreManager.instance.UpdatePoint();
        A.Play();
    }
    //deze laden de specifieke scenes
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
    }

}
