using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{

    public enum ItemType
    {
      ExtraBomb,
      LargeRadius,
      SpeedUp
    }

    public ItemType type;
  
     private void OnTriggerEnter2D(Collider2D other)
     {
         if(other.CompareTag("Player"))
         {
           OnItemPickup(other.gameObject);
         }
     }

     private void OnItemPickup(GameObject player)
     {
        switch(type)
        {
           case ItemType.ExtraBomb :
           player.GetComponent<BombCOntroler>().AddBomb();
           break;

           case ItemType.LargeRadius :
           player.GetComponent<BombCOntroler>().radious++;
           break;

           case ItemType.SpeedUp :
           player.GetComponent<playerMovement>().speed++;
           break;


        }
        Destroy(gameObject);
     }
}
