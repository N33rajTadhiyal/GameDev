using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] run;
    public Sprite climb;
    public Sprite jump;
    public Sprite Idel;
    private int SpriteIndex;


   private Vector2 direction;
   private Rigidbody2D myrb;

   private new Collider2D collider;
   private Collider2D[] result;

   public  float speed=3;
   public float jumpforce;

  private bool grounded;
  private bool climbing;


   private async void CheckCollisoin()
   {
       grounded=false;
       climbing=false;
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
         else if(hit.layer==LayerMask.NameToLayer("ladder"))
         {
             climbing=true;
         }
      }
   }

   //Animating the Sprite
    private void OnEnable()
   {
    InvokeRepeating(nameof(Animate),1f/12f,1f/12f);
   }
   private void OnDisable()
   {
    CancelInvoke();
   }
   

   // Setting refrences of the Game components
   void Awake()
   {
      spriteRenderer = GetComponent<SpriteRenderer>();
      myrb=GetComponent<Rigidbody2D>();
      result=new Collider2D[4];
      collider = GetComponent<Collider2D>();
   }
   void Update()
   {
    CheckCollisoin();

     if( climbing)
     {
            direction.y= Input.GetAxis("Vertical")*speed;
     }
     else if(grounded && Input.GetButtonDown("Jump"))
     {
         direction=Vector2.up*jumpforce;
     }
     else{
         direction+=Physics2D.gravity*Time.deltaTime;
     }

       // moving our character
       direction.x = Input.GetAxisRaw("Horizontal")*speed;
       
       //stoping y's value at -1 if we are grounded so that it wont cause probluems at walking the character
       if(grounded)
       {
            direction.y=Mathf.Max(direction.y,-1f);
       }

         //changing the face of our character 
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
       myrb.MovePosition(myrb.position+direction*Time.fixedDeltaTime);
   }
   void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.layer==LayerMask.NameToLayer("barrel"))
       {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       }
   }
 
void Animate()
{         
         if(climbing)
         {
            spriteRenderer.sprite=climb;
         }
         else if(!grounded)
         {
            spriteRenderer.sprite=jump;
         }
         else if(direction.x!=0)
          {
             SpriteIndex++;
             if(SpriteIndex>=run.Length)
             {
                 SpriteIndex=0;
             }
             spriteRenderer.sprite=run[SpriteIndex];
         }
         else if(direction.x==0)
         {
            spriteRenderer.sprite=Idel;
         }
}


}
