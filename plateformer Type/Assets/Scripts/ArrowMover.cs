using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour
{
   private Rigidbody2D arrow;
   public float speed=5.0f;
   private Animation anime;

   private SpriteRenderer spriteRenderer;
   


    void Start()
    {
        arrow=GetComponent<Rigidbody2D>();
        anime=GetComponent<Animation>();
        arrow.transform.eulerAngles= new Vector3(0.0f,0.0f,-90.0f);
       
        
    }
    // Update is called once per frame
    void Update()
    {
         
        arrow.velocity=Vector2.left*speed;
        //Destroy(gameObject,2.0f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
           
      
           Destroy(gameObject);
       }
      
    }
}
