using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddle : MonoBehaviour
{

    Vector3 direction= Vector3.up;
    public float speed=1f;
    public float max;
   

    // Start is called before the first frame update
    void Start()
    {
        max =Camera.main.ScreenToWorldPoint(Vector3.zero).y+26;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         transform.position+= direction*speed*Time.deltaTime; 
         if(transform.position.y>max)
         {
             Destroy(gameObject);
         }      
        
    }}
    
