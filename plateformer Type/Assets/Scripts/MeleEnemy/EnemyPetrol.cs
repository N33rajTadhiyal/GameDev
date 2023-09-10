using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPetrol : MonoBehaviour
{
   [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;


    [Header("Enemy")]
    [SerializeField] private Transform enemy;
   
    [Header("Movement Parameters")]
    [SerializeField] private float speed;

    private void MoveInDirection(int _direction)
    {
      enemy.position= new Vector3(enemy.position.x+Time.deltaTime*speed,enemy.position.y,enemy.position.z);
    }
}
