using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balmovement : MonoBehaviour
{

   private Rigidbody2D myrb;
   private Vector2 direction;

   public float force;
    // Start is called before the first frame update
    void Start()
    {
        myrb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction= Vector2.up*force;
            
        }
        direction+= Physics2D.gravity*Time.deltaTime;
    }
    void FixedUpdate()
    {
        myrb.MovePosition(myrb.position+direction);
       
    }
}
