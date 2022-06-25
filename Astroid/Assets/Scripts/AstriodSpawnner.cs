using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstriodSpawnner : MonoBehaviour
{
    public Astroids astroidPrefab;
    public float spawnRate=1.0f;
    public int spawnAmount=1;

    public float trajectoryVariance=15.0f;

    public float spawnDistance=10.0f;
    public void Start()
    {
        InvokeRepeating(nameof(Spawn),spawnRate,spawnRate);
    }
    public void Spawn()
    {
    for(int i =0;i<spawnAmount;i++)
    {
         Vector3 SpawnDirection = Random.insideUnitCircle.normalized*this.spawnDistance;
         Vector3 SpawnPosition = this.transform.position+SpawnDirection;

         float Variance=Random.Range(-this.trajectoryVariance,this.trajectoryVariance);
         Quaternion rotation=Quaternion.AngleAxis(Variance,Vector3.forward);

         Astroids astroid = Instantiate(astroidPrefab,SpawnPosition,rotation);
         astroid.size=Random.Range(astroid.minsize,astroid.maxsize);

         astroid.SetTrajectory(rotation*-SpawnDirection); 
    }
    }
}
