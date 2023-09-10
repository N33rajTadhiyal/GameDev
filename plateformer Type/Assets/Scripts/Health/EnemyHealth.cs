using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private Animator anim;
    [SerializeField]private int MaxHealth=3;
     public int currentHealth=0;
     
     private void Awake()
     {
         currentHealth=MaxHealth;
     }
  

    public void TakeDamage(int damage)
    {
       currentHealth=Mathf.Clamp(currentHealth-damage,0,MaxHealth);
    }
     public void Heal(int health)
    {
       currentHealth=Mathf.Clamp(currentHealth+health,0,MaxHealth);
    }
}
