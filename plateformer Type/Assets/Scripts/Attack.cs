using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackcooldown;//the time need to pass before firing next shot
    private float cooldowntimer =Mathf.Infinity;//time hase passed after firing the shot 

    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    PlayerController pc;

    void Start()
    {
       pc = GetComponent<PlayerController>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetMouseButtonDown(0) && pc.CanAttack() && cooldowntimer>=attackcooldown)
      {
          attack();
          FindObjectOfType<Shooting>().Shoot();
      }
      cooldowntimer+=Time.deltaTime;
     
    }

   public void attack()
    {  
       anim.SetTrigger("attacking");
       cooldowntimer=0;
      // fireballs[0].transform.position=SpawnPoint.position;
      // fireballs[0].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}
