using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   private Vector2 direction;
   private Rigidbody2D myrb;

   private new Collider2D collider;
   private Collider2D[] result;

   public  float speed=3;
   public float jumpforce;

  private bool grounded;


   private async void CheckCollisoin()
   {
       grounded=false;
       Vector2 size= collider.bounds.size;
       size.x /= 2.0f;
       size.y += 0.1f;

      int amount= Physics2D.OverlapBoxNonAlloc(transform.position,size,0.0f,result);

      for(int i=0;i<amount;i++)
      {
         GameObject hit= result[i].gameObject;
         if(hit.layer==LayerMask.NameToLayer("ground"))
         {
           grounded= hit.transform.position.y< (transform.position.y-0.5f);
           Physics2D.IgnoreCollision(collider,result[i],!grounded);
         }
      }
   }
   
   void Awake()
   {
      myrb=GetComponent<Rigidbody2D>();
      result=new Collider2D[4];
      collider = GetComponent<Collider2D>();
   }
   void Update()
   {
    CheckCollisoin();

     if(grounded && Input.GetButtonDown("Jump"))
     {
         direction=Vector2.up*jumpforce;
     }
     else{
         direction+=Physics2D.gravity*Time.deltaTime;
     }

       direction.x = Input.GetAxisRaw("Horizontal");
       
       if(grounded)
       {
            direction.y=Mathf.Max(direction.y,-1f);
       }

       if(direction.x>0f)
       {
           transform.eulerAngles=Vector3.zero;
       }
       else if(direction.x<0f)
       {
           transform.eulerAngles=new Vector3(0.0f,180f,0);
       }
   }

   void FixedUpdate()
   {
       myrb.MovePosition(myrb.position+direction*speed*Time.fixedDeltaTime);
   }



}
