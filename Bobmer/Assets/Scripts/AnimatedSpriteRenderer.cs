using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    public Sprite[] animatedSprites;
    public Sprite IdelSprite;
    public int SpriteIndex=0;
    public float Timepass=0.25f;

    public bool loop=true;
    public bool idel=true;

    public void Awake()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }
    
    
    private void OnEnable()
    {
        spriteRenderer.enabled=true;
    }

        private void OnDisable()
    {
        spriteRenderer.enabled=false;
    }
    

    void Start()
    {
        InvokeRepeating(nameof(NextFrame),Timepass,Timepass);
    }

   
   private void NextFrame()
   {
       SpriteIndex++;
       if(loop&& SpriteIndex>=animatedSprites.Length)
       {
           SpriteIndex=0;
       }

       if(idel)
       {
           spriteRenderer.sprite=IdelSprite;
       }
       else if(SpriteIndex>=0 && SpriteIndex<animatedSprites.Length){
           spriteRenderer.sprite=animatedSprites[SpriteIndex];
       }

   }

}
