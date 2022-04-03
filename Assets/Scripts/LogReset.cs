using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogReset : MonoBehaviour
{
    private GameObject log;
    private Vector3 logOrigin;

    void Awake()
    {
        log = GameObject.Find("Log");
        logOrigin = new Vector3(log.transform.position.x, log.transform.position.y, log.transform.position.z);
        Debug.Log(logOrigin);
    }

    void Update()
    {
        Debug.Log(log.gameObject.name);
        if (log.GetComponent<Rigidbody>().velocity.z < 1)
        {
            log.GetComponent<Rigidbody>().AddForce(0,0,1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == log)
        {
            log.transform.position = logOrigin;
        }
    }

}
