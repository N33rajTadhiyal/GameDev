using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum playerState{
    idel,
    walk,
    attack,
    dead
}
public class playerController : MonoBehaviour
{
    public playerState currentState;
    public float speed = 2f;
    private Rigidbody2D myrb;
    private Animator anim;
    private Vector3 change;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        currentState=playerState.idel;
        anim = GetComponent<Animator>();
        myrb = GetComponent<Rigidbody2D>();
        sp=GetComponent<SpriteRenderer>();

        
            anim.SetFloat("movex",0f);
            anim.SetFloat("movey", -1f);
    }

    // Update is called once per frame
    void Update()
    {
         anim.SetBool("swordAttak",false);

        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        updateAnimation();

        if(Input.GetKeyDown(KeyCode.Mouse0) && currentState!=playerState.walk)
        {
            StartCoroutine(AttackCo());
                        
        }
    }

    void movePlayer()
    {
        change.Normalize();
        myrb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void updateAnimation()
    {
        if (change != Vector3.zero)
        {
            currentState=playerState.walk;
            movePlayer();
            anim.SetFloat("movex", change.x);
            anim.SetFloat("movey", change.y);
            anim.SetBool("iswalking", true);
        }
        else
        {
            anim.SetBool("iswalking", false);
            
        }
        if(change==Vector3.zero && currentState!=playerState.attack)
        {
            currentState=playerState.idel;
        }
    }
    


    IEnumerator AttackCo(){
            currentState=playerState.attack;
            anim.SetBool("swordAttak",true);
            yield return null;      
                 
            anim.SetBool("swordAttak",false);
            yield return new WaitForSeconds(.3f);
            currentState=playerState.idel;
    }
}
