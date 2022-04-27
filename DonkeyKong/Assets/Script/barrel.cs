using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrel : MonoBehaviour
{
    private Rigidbody2D myrb;
    public float speed=2f;
    // Start is called before the first frame update
    void Awake()
    {
        myrb=GetComponent<Rigidbody2D>();  
    }

   void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.layer==LayerMask.NameToLayer("ground"))
       {
           myrb.AddForce(other.transform.right*speed,ForceMode2D.Impulse);

       }
   }
}
