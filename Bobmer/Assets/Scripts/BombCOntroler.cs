using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombCOntroler : MonoBehaviour
{
    [Header("Bomb")]
    public GameObject BombPrefab;
    public int totalBombs=1;
    public int remaningBombs=0;
    public float BombFuseTime=3.0f;

    public KeyCode BombDroperButton=KeyCode.Space;

    [Header("Explosion")]
    public Explosion explosionprefab;
    public int radious=1;
    public int explosionDuration=1;
    public LayerMask explosionLayerMask;

    [Header("Destructable")]
    public Destructable destructablepreab;
    public Tilemap destructableTiles;

    void OnEnable()
    {
        remaningBombs=totalBombs;
    }
 

    void Update()
    {
         if(Input.GetKeyDown(BombDroperButton)&&remaningBombs>0)
        {
            remaningBombs--;
            StartCoroutine(PlaceBomb());
        }
    }




    private IEnumerator PlaceBomb()
    {
        Vector2 position=transform.position;
        position.x=Mathf.Round(position.x);
        position.y=Mathf.Round(position.y);

        GameObject bomb =Instantiate(BombPrefab,position,Quaternion.identity);
        yield return new WaitForSeconds(BombFuseTime);
        
        position=bomb.transform.position;
        position.x=Mathf.Round(position.x);
        position.y=Mathf.Round(position.y);
        
        Explosion explosion=Instantiate(explosionprefab,position,Quaternion.identity);
        explosion.ActivateSprite(explosion.start);   
        explosion.DestroyAfter(explosionDuration);     
        Destroy(explosion.gameObject,explosionDuration);
       
        Explode(position,Vector2.up,radious);
        Explode(position,Vector2.down,radious);
        Explode(position,Vector2.left,radious);
        Explode(position,Vector2.right,radious);



        Destroy(bomb);
        
        remaningBombs++;


    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if(other.gameObject.layer==LayerMask.NameToLayer("Bomb"))
         {
             other.isTrigger=false;
         }
    }

    public void Explode(Vector2 position,Vector2 direction,int length)
    {
        if(length<=0)
        {
            return;
        }       

        position+=direction;

         if(Physics2D.OverlapBox(position,Vector2.one/2.0f,0f,explosionLayerMask))
        {
            ClearDestructable(position);
            return;
        }

        Explosion explosion=Instantiate(explosionprefab,position,Quaternion.identity);
        explosion.ActivateSprite(length>1?explosion.middle:explosion.end);   
        explosion.SetDirection(direction); 

        explosion.DestroyAfter(explosionDuration);    
        Destroy(explosion.gameObject,explosionDuration);

        Explode(position,direction,length-1);

    }
    private void ClearDestructable(Vector2 position)
    {
        Vector3Int cell=destructableTiles.WorldToCell(position);
        TileBase tile=destructableTiles.GetTile(cell);
        if(tile!=null)
        {
            Instantiate(destructablepreab,position,Quaternion.identity);
            destructableTiles.SetTile(cell,null);
        }

    }

    public void AddBomb()
    {
        totalBombs++;
        remaningBombs++;
    }
}
