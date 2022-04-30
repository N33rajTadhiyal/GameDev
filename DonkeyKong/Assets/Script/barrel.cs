using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class barrel : MonoBehaviour
{
    private Rigidbody2D myrb;
    public float speed=2f;
    public int Index;
    // Start is called before the first frame update
    void Awake()
    {
        myrb=GetComponent<Rigidbody2D>();  
        int Index= SceneManager.GetActiveScene().buildIndex;
        speed=(speed+Index)*3;
        
    }

   void OnCollisionEnter2D(Collision2D other)
   {
       if(other.gameObject.layer==LayerMask.NameToLayer("ground"))
       {
           myrb.AddForce(other.transform.right*speed,ForceMode2D.Impulse);
                
       }
   }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag=="destroy")
       {
           Destroy(this.gameObject,2);
       }
   }
}
