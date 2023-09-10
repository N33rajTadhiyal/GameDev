using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float AttackCooldown;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float AttackCooldownTimer=Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;

    private Animator anim;
    private HealthSystem playerhealth;

    private void Start()
    {
       anim=GetComponent<Animator>();
    }

   

    // Update is called once per frame
    void Update()
    {
        AttackCooldownTimer+=Time.deltaTime; 

        if(InSeight())
        {
            if(AttackCooldownTimer>=AttackCooldown)
            {
                 AttackCooldownTimer=0;
                 anim.SetTrigger("attacking");
            }
        }
    }

    private bool InSeight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance,
         new Vector3( boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z),
         0,Vector2.left,0,playerLayer);

         if(hit.collider!=null)
         {
             playerhealth=hit.transform.GetComponent<HealthSystem>();
         }
        return hit.collider!=null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center+transform.right*range*transform.localScale.x*colliderDistance,
       new Vector3( boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if(InSeight())
        {
          playerhealth.TakeDamage(damage);
        }
    }
}
