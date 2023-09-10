using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleEnemyController : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D myrb;

    public EnemyHealth enemyhealth;

    public void Start()
    {
      myrb= GetComponent<Rigidbody2D>();
      anim=GetComponent<Animator>();
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.CompareTag("fireball"))
      {
          enemyhealth.TakeDamage(1);
          if(enemyhealth.currentHealth>0)
          {
            anim.SetTrigger("hurt");
          }
          else
          {
            anim.SetTrigger("dead");
            StartCoroutine(OneSecPause());
            
          }
          
      }
    }

    public IEnumerator OneSecPause()
    {
      yield return new WaitForSeconds(2);
      anim.gameObject.SetActive(false);
    }
}
