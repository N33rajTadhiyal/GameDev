using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float speed=1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( target.position.y > transform.position.y)
        {
            Vector3 newpos = new Vector3(transform.position.x,target.position.y,transform.position.z);
            transform.position= Vector3.Lerp(transform.position,newpos,speed);
        }
    }
}
