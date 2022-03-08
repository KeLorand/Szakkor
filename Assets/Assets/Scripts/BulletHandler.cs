using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    public Rigidbody2D bulletRB;
    public int bulletSpeed;
    public  BoxCollider2D bulletCol;
    

    void Awake()
    {
        bulletRB = this.gameObject.GetComponent<Rigidbody2D>();
        bulletCol = this.gameObject.GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {

        if (Input.GetKey("space"))
        {
            bulletSpeed = 0;
        }

        this.transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);

        if (PlayerMovement.enemyCollider != null)
        {
            if (bulletCol.IsTouching(PlayerMovement.enemyCollider) && EnemyScript.health >= 20)
            {
                EnemyScript.health = EnemyScript.health - 20;
                Debug.Log(EnemyScript.health);
                Destroy(this.gameObject);
            }
        }

        if (PlayerMovement.playerCollider.IsTouching(bulletCol))
        {
            PlayerMovement.canJump = true;
        }
        
    }
}
