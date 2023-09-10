using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D myrb{ get; private set;}

    private Vector2 direction = Vector2.down;
    public float speed = 6f;

    public KeyCode InputDown= KeyCode.S;
    public KeyCode InputUp= KeyCode.W;
    public KeyCode InputRight= KeyCode.D;
    public KeyCode InputLeft= KeyCode.A;

    public AnimatedSpriteRenderer SpriteRendererUp;
    public AnimatedSpriteRenderer SpriteRendererDown;
    public AnimatedSpriteRenderer SpriteRendererLeft;
    public AnimatedSpriteRenderer SpriteRendererRight;
    public AnimatedSpriteRenderer SpriteRendererDeath;

    private AnimatedSpriteRenderer ActiveSpriteRenderer;

    private void Awake()
    {
        myrb = GetComponent<Rigidbody2D>();
        ActiveSpriteRenderer=SpriteRendererDown;
    }    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(InputDown))
        {
            SetDirection(Vector2.down,SpriteRendererDown);
        }
        else if(Input.GetKey(InputUp))
        {
              SetDirection(Vector2.up,SpriteRendererUp);
        }
        else if(Input.GetKey(InputRight))
        {
              SetDirection(Vector2.right,SpriteRendererRight);
        }
        else if(Input.GetKey(InputLeft))
        {
              SetDirection(Vector2.left,SpriteRendererLeft);
        }
        else
        {
         SetDirection(Vector2.zero,ActiveSpriteRenderer);
        }
    }

    private void FixedUpdate()
    {
        myrb.MovePosition(myrb.position+direction*speed*Time.fixedDeltaTime);
    }

    private void SetDirection(Vector2 dir,AnimatedSpriteRenderer spriteRenderer)
    {
        direction=dir;
        SpriteRendererUp.enabled = (spriteRenderer==SpriteRendererUp);
        SpriteRendererDown.enabled = spriteRenderer==SpriteRendererDown;
        SpriteRendererLeft.enabled = spriteRenderer==SpriteRendererLeft;
        SpriteRendererRight.enabled = spriteRenderer==SpriteRendererRight;

        ActiveSpriteRenderer=spriteRenderer;
        ActiveSpriteRenderer.idel=direction==Vector2.zero;
    }

   private void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.layer == LayerMask.NameToLayer("Explosion"))
      {
        
          DeathSequece();

      }
     
    }

    private void DeathSequece()
    {
        enabled=false;
        GetComponent<BombCOntroler>().enabled=false;

        SpriteRendererDown.enabled=false;
        SpriteRendererUp.enabled=false;
        SpriteRendererLeft.enabled=false;
        SpriteRendererRight.enabled=false;
        SpriteRendererDeath.enabled=true;
        Invoke(nameof(OnDeathSequenceEnd),1f);
    }
    
    private void OnDeathSequenceEnd()
    {
        gameObject.SetActive(false);
        FindObjectOfType<Gamemanager>().CheckWins();
    }
}
