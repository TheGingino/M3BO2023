using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : MonoBehaviour
{
    public GameObject newsPaper;
    public AudioSource mail;

    bool wasHit;

    //collider contact voor score
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("NewsPaper"))
        {
            if (!wasHit)
            {
                newsPaper.SetActive(true);
                mail.Play();
                //score systeem
                ScoreManager.instance.AddPoint(); //geeft punten als je de mailbox raakt
            }
        }
    }
}
