using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask groundlayer;
    private BoxCollider2D boxcollider;
    private Rigidbody2D myrb;
    public Animator anime;
    private Vector2 direction;
    public float speed=5,jumpforce=7;
    public bool isattacking =false;
    
   


    
    // Start is called before the first frame update
    void Start()
    {
        myrb = GetComponent<Rigidbody2D>();
        boxcollider= GetComponent<BoxCollider2D>();
       
    }

    // Update is called once per frame
    void Update()
    { 
        
      
      direction.x = Input.GetAxis("Horizontal");
   
        // function to change the direction our character is facing
        FacingDirectionChange();
  

        // moving player
         MovePlayer();

        // jumping ans setting animation
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jump();
        }

        //jumping animation
        if(IsGrounded())
        {
           
            anime.SetBool("jump",false);
        }else{
            anime.SetBool("jump",true);
        }

         // setting walking animation
         anime.SetBool("walking",direction.x!=0);


    
        
        
    
    }

   private void MovePlayer()
   {
     myrb.velocity= new Vector2(Input.GetAxisRaw("Horizontal")*speed,myrb.velocity.y);
   }

   private void jump()
   {
       myrb.velocity= new Vector2(myrb.velocity.x,speed);      
   }

   private void FacingDirectionChange()
   {
       if(direction.x>0)
      {
         // myrb.transform.localScale= Vector3.one;
          myrb.transform.eulerAngles= Vector3.zero;
         
      }
      else if(direction.x<0)
      {
         // myrb.transform.localScale=new Vector3(-1,1,1);
         myrb.transform.eulerAngles=new Vector3(0,180,0);
           
      }
   }

  

    private bool IsGrounded()
    {
        RaycastHit2D raycasthit=Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,Vector2.down,0.2f,groundlayer);
        return raycasthit.collider!=null;
    }

    private bool isIdel()
    {
        if(direction==Vector2.zero)
        {
            return true;
        }
        return false;
    }


    public bool CanAttack()
    {
       return isIdel() && IsGrounded();
    }

    
    


  
    
}
