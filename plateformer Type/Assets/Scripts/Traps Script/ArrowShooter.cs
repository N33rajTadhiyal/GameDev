using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    
    public GameObject arrowPrefab;
    public Transform trap;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if(other.gameObject.CompareTag("Player"))
        {
           Shoot();
        }
        if(other.gameObject.CompareTag("fireball"))
        {
            Destroy(gameObject);
        }
    }
    private void Shoot()
    {
       GameObject arrow= Instantiate(arrowPrefab,trap.position,Quaternion.identity);
       
    }
}
