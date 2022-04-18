using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D myrb;
    public float speed =10f;

    private bool isPinned=false;

    // Update is called once per frame
    void Update()
    {
        if(!isPinned)
        {
            myrb.MovePosition(myrb.position+Vector2.up*speed*Time.deltaTime);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Aim")
        {
            transform.SetParent(other.transform);
            isPinned=true;
        }
    }
}
