using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{

  private Rigidbody2D myrb;
  private bool _thrusting;
  private float _Turndirection;

  public float turnSpeed=1.0f;
  public float thrustSpeed=1.0f;

  public bullet bulletPrefab;  



  void Awake()
  {
    myrb = GetComponent<Rigidbody2D>();
  }

  void Update()
  {
     _thrusting=(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow));

     if(Input.GetKey(KeyCode.A) ||Input.GetKey(KeyCode.LeftArrow) )
     {
       _Turndirection=1.0f;
       
     }
     else if(Input.GetKey(KeyCode.D) ||Input.GetKey(KeyCode.RightArrow) )
     {
       _Turndirection=-1.0f;
     }
     else{
         _Turndirection=0.0f;
     }

    if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
    {
      Shoot();
    }


  }

  void FixedUpdate()
  {
    if(_thrusting)
    {
      myrb.AddForce(this.transform.up*thrustSpeed);
    }
    if(_Turndirection!=0)
    {
      myrb.AddTorque(_Turndirection*turnSpeed);
    }
  }

  private void Shoot()
  {
    bullet bull=Instantiate(bulletPrefab,transform.position,transform.rotation);
    bull.Fire(transform.up);
  }

  public void OnCollisionEnter2D(Collision2D other)
  {
    if(other.gameObject.tag=="Astroid")
    {
      myrb.velocity=Vector3.zero;
      myrb.angularVelocity=0.0f;
      this.gameObject.SetActive(false);      
      FindObjectOfType<GameManager>().PlayerDied();
    }
  }

  
    

}
