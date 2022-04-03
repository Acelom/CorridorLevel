using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpCamera : MonoBehaviour
{
    public Camera SWCamera;

    void Start()
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        SWCamera.enabled = true;
    }
}
