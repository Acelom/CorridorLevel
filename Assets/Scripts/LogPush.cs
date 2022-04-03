using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPush : MonoBehaviour
{
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 1f);    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Rigidbody>().AddForce(0, 0, (player.transform.position.z - gameObject.transform.position.z) * 100);
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            player.GetComponent<Rigidbody>().AddForce(0, 0, (player.transform.position.z - gameObject.transform.position.z) * 100);
        }
    }

}
