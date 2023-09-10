using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
   [Header("Health")]
   public int MaxHealth=3;
   public float CurrentHealth{get;private set;}
   public Animator anime;
   private Rigidbody2D myrb;
   public HealthBarScript HealthSetter;
   private bool isDead=false;

   [Header("Immortality")]
   [SerializeField] private float ImmortalityTime=2.0f;
   [SerializeField] private int NumberOfFlashes=4;

   private SpriteRenderer spriteRenderer;
   

 
    void Start()
    {
      CurrentHealth=MaxHealth; 
      HealthSetter.SetMaxHealthBar(CurrentHealth); 
      myrb=GetComponent<Rigidbody2D>(); 
      spriteRenderer =GetComponent<SpriteRenderer>();
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Arrow"))
       {
           
            TakeDamage(1);          
           
                  
       }
    }

    private void DisableEverything()
    {
        GetComponent<PlayerController>().enabled=false;
        GetComponent<Shooting>().enabled=false;
        GetComponent<Attack>().enabled=false;    
          
    }


    private IEnumerator ResetScene()
    {
       yield return new WaitForSeconds(2);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddHealth(float health)
    {
        if(!isDead)
        {
             CurrentHealth=Mathf.Clamp(CurrentHealth+health,0,MaxHealth);
        }
    }
    public void TakeDamage(float damage)
    {
        CurrentHealth=Mathf.Clamp(CurrentHealth-damage,0,MaxHealth);
        if(CurrentHealth<=0)
           {
           //  myrb.gameObject.SetActive(false);
              
              isDead=true;
              anime.SetTrigger("Dead");
              DisableEverything();
              StartCoroutine(ResetScene());
           }
           else{
               StartCoroutine(Immortal());
               anime.SetTrigger("hurt");             
              
           }   
    }
    
    private IEnumerator Immortal()
    {
        Physics2D.IgnoreLayerCollision(7,8,true);
        for (int i = 0; i < NumberOfFlashes; i++)
        {
             spriteRenderer.color= new Color(0,0,0,0f);
             yield return new WaitForSeconds(0.09f);
             spriteRenderer.color= Color.white;
             yield return new WaitForSeconds(0.09f);

        }
        
        Physics2D.IgnoreLayerCollision(7,8,false);

    }
}
