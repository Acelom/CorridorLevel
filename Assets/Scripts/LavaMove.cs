using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaMove : MonoBehaviour
{
    public Material mat;
    private float elapsedTime;
    public int maxTime; 
    private void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        mat.mainTextureOffset = new Vector2(elapsedTime/maxTime, elapsedTime/maxTime);
        if (elapsedTime > maxTime)
        {
            elapsedTime = 0; 
        }
    }
}
