using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState{
    idel,
    attack,
    dead
}
public class enemy : Enemy1
{

    public EnemyState EnemyCurrentState;
    private Rigidbody2D myrb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        EnemyCurrentState=EnemyState.idel;
        myrb=GetComponent<Rigidbody2D>();
        anim =GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(){
        EnemyCurrentState=EnemyState.dead;
           anim.SetBool("hit",true);
    }
}
