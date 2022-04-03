using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickup : MonoBehaviour
{
    private GameObject player;
    private bool pickedUp;
    private float time;
    private bool allowInput = true;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    void Update()
    {
         if (Input.GetButtonUp("Pickup"))
         {
            allowInput = true; 
         }

    }
    void OnTriggerStay(Collider other)
    {
        if (Input.GetButton("Pickup")) 
        {
            if (other.gameObject == player)
            {
                if (!pickedUp & allowInput)
                {
                    gameObject.GetComponent<Collider>().enabled = false;
                    gameObject.transform.parent = player.transform;
                    pickedUp = true;
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    allowInput = false;
                }
                if (pickedUp & allowInput)
                {
                    gameObject.GetComponent<Collider>().enabled = true; 
                    gameObject.transform.parent = null;
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                    pickedUp = false;
                    allowInput = false; 
                }
            }
        }
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if (pickedUp) 
        {
            gameObject.transform.localPosition = new Vector3(0,  Mathf.Sin(time)/4 + 1 , 1);
        }
        
        if (time > 6.28)
        {
            time = 0;
        }
    }
}
