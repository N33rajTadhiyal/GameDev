using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myrb;

    public Animator anim;
    public BoxCollider2D box;

    private float destroytime=1;//if bullet dont hit anything it will destroy after destroy time
    private float destroyT=0;//time hase passes since we fire the FIREBALLLLLLLLL
    // Start is called before the first frame update
    void Start()
    {
        myrb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        myrb.velocity= transform.right*speed;
       // Destroy(gameObject,1);
       destroyT += Time.deltaTime;
       
       if(destroyT>= destroytime)
       {     myrb.velocity=Vector2.zero;
             anim.SetTrigger("blast"); 
             Destroy(gameObject,0.5f);
       }
    }

    public void OnCollisionEnter2D(Collision2D other)
      {
         myrb.velocity=Vector2.zero;
         
         anim.SetTrigger("blast"); 
      }

         private void Deactivate()
      {
          gameObject.SetActive(false);
      }
}
