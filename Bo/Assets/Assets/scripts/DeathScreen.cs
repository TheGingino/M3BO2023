using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject gameOverUI;
    public Text pointsText;

    // Start is called before the first frame update
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS";
        ScoreManager.instance.UpdatePoint();
    }

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
