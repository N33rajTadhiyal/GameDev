using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectable : MonoBehaviour
{
   public float healthvalue=1f;

   private void OnTriggerEnter2D(Collider2D other)
   {
       if(other.CompareTag("Player"))
       {
           other.GetComponent<HealthSystem>().AddHealth(healthvalue);
           gameObject.SetActive(false);
       }
   }
}
