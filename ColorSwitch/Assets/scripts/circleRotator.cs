using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circleRotator : MonoBehaviour
{
    public float speed=3;
    public void Update()
    {
        transform.Rotate(0.0f,0.0f,speed*Time.deltaTime);
    }
}
