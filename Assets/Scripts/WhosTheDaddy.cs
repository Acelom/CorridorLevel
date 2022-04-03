using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhosTheDaddy : MonoBehaviour
{
    private GameObject player;
    private GameObject log; 


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        log = GameObject.Find("Log");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
        }
    }
}
