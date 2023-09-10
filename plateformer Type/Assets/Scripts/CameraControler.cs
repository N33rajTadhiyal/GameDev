using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float speed;
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(player.position.x,transform.position.y,transform.position.z);
    }
}
