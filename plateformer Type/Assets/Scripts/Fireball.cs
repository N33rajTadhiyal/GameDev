using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
     public BoxCollider2D box;
     public Animator anim;
     public float speed=8;
     public bool hit;
     private float direction;

     private Rigidbody2D myrb;

      void start()
      {
         
         myrb= GetComponent<Rigidbody2D>();

      }
      void update()
      {
          if(hit)
          {
              return;
          }
        float movementspeed=speed*Time.deltaTime*direction;
        transform.Translate(movementspeed,0,0);
         
      }

      public void OnCollisionEnter2D(Collision2D other)
      {
         hit=true;
         box.enabled=false;
         anim.SetTrigger("blast"); 
      }

      public void OnTriggerEnter2D(Collider2D other)
      {
         
      }

      public void SetDirection( float _direction)
      {
          Debug.Log(_direction);
          direction=_direction;
          gameObject.SetActive(true);
          hit=false;
          box.enabled=true;

          float localScaleX=transform.localScale.x;
          if(Mathf.Sign(localScaleX)!= _direction)
          {
              localScaleX=-localScaleX;
          }

          transform.localScale= new Vector3(localScaleX,transform.localScale.y,transform.localScale.z);
      }

      private void Deactivate()
      {
          gameObject.SetActive(false);
      }
}
