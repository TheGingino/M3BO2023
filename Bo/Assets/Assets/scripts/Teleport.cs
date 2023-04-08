using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Target;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Player.transform.position = Target.transform.position; // brengt je terug naar het begin als je bij het einde komt
    }
}
