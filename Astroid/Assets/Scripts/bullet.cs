using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Rigidbody2D myrb;
    public float speed=100f;
    public float LifeSpan=10;

    void Awake()
    {
        myrb = GetComponent<Rigidbody2D>();        
    }

    public void Fire(Vector2 direction)
    {
        myrb.AddForce(direction*speed);
        Destroy(this.gameObject,LifeSpan);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
          Destroy(this.gameObject);
    }
}
