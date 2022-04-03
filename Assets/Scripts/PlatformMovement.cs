using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject pos0;
    public GameObject pos1;
    public GameObject pos2;
    public GameObject pos3;

    public float waitTime = 1.0f;
    public float speed = 2.0f;
    public int nextPos = 0;
    private float elapsedTime = 0;

    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float step = speed * Time.deltaTime;
        if (elapsedTime > waitTime)
        {
          switch (nextPos)
            {
                case 0:
                    transform.position = Vector3.MoveTowards(transform.position, pos0.transform.position, step);
                    break; 
                case 1:
                    transform.position = Vector3.MoveTowards(transform.position, pos1.transform.position, step);
                    break;
                case 2:
                    transform.position = Vector3.MoveTowards(transform.position, pos2.transform.position, step);
                    break; 
                case 3:
                    transform.position = Vector3.MoveTowards(transform.position, pos3.transform.position, step);
                    break; 
            }
        }
        switch (nextPos)
        {
            case 0:
                if (transform.position == pos0.transform.position)
                {
                    nextPos = 1;
                    elapsedTime = 0;
                }
                break;
            case 1:
                if (transform.position == pos1.transform.position)
                {
                    nextPos = 2;
                    elapsedTime = 0;
                }
                break;
            case 2:
                if (transform.position == pos2.transform.position)
                {
                    nextPos = 3;
                    elapsedTime = 0;
                }
                break;
            case 3:
                if (transform.position == pos3.transform.position)
                {
                    nextPos = 0;
                    elapsedTime = 0;
                }
                break;
        }
    }
}
