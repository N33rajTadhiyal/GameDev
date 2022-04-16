using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 direction;
    public Rigidbody2D myrb;    
    public float speed=7;     
    public GameObject  hitsound,poisonsound;
    

    
    void Start()
    {
        myrb =GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        direction.x=Input.GetAxisRaw("Horizontal");
        direction=direction.normalized;       

    }
    void FixedUpdate()
    {
       myrb.velocity= direction*speed;
       
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="log")
        {
           Instantiate(hitsound,transform.position,transform.rotation);
           speed=10;
        }
       else if(other.gameObject.tag=="poison")
        {            
            Instantiate(poisonsound,transform.position,transform.rotation);
            
           speed=8;
        }
        else if(other.gameObject.tag=="jump")
        {

            myrb.AddForce(Vector2.up*12*Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("barrior"))
        {
         FindObjectOfType<GameManager>().GameOver(2);
            
        }

    }
  
}
