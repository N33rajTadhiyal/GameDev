using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoller : MonoBehaviour
{



  public float speed=2f;
  public Rigidbody2D myrb;

  private Vector3 change;

    // Start is called before the first frame update
    void Start()
    {
       myrb=GetComponent<Rigidbody2D>();
    }
  void update()
  {
    change=Vector3.zero;

    change.x=Input.GetAxisRaw("Horizontal");
    change.y=Input.GetAxisRaw("Vertical");
    Debug.Log(Input.GetAxisRaw("Horizontal"));
    
    if(change!=Vector3.zero)
    {
        
        MoveCharacter();
    }

  }


    public void MoveCharacter(){
        myrb.MovePosition( transform.position + change *speed*Time.deltaTime);
    }
   
}
