using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroids : MonoBehaviour
{
   public Sprite[] sprites;
   public SpriteRenderer _spriteRenderer;
   private Rigidbody2D myrb;

   public float size=1.0f;
   public float minsize=0.5f;

   public float maxsize=1.5f;

   public float speed=30.0f;
   public float lifeTime=10.0f;

 

   private void Awake()
   {
       myrb=GetComponent<Rigidbody2D>();
       _spriteRenderer= GetComponent<SpriteRenderer>();
   }

   public void Start()
   {
       _spriteRenderer.sprite=sprites[Random.Range(0,sprites.Length)];
       this.transform.eulerAngles= new Vector3(0.0f,0.0f,Random.value*360.0f);
       this.transform.localScale=Vector3.one*this.size;
       myrb.mass=this.size;

    
   }

   public void SetTrajectory(Vector3 direction)
   {
       myrb.AddForce(direction*this.speed);
       Destroy(this.gameObject,lifeTime);
   }

   public void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.tag=="Bullet")
       {
          if( (this.size/2f)>=this.minsize)
          {
            CreateSplit();
            CreateSplit();
          }
          FindObjectOfType<GameManager>().AstroidDied(this);
       
          Destroy(this.gameObject);
       }
   }
   private void CreateSplit()
   {
     Vector2 position= transform.position;
     position+=Random.insideUnitCircle*0.5f;
     Astroids half=Instantiate(this,position,transform.rotation);
     half.size=this.size/2;
     half.SetTrajectory(Random.insideUnitCircle.normalized*this.speed );
   }

}
