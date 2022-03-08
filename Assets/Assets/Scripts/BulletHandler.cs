using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{

    public Rigidbody2D bulletRB;
    public int bulletSpeed;
    public Rigidbody2D bulletCol;
    public GameObject enemyObject;
    public BoxCollider2D enemyCollider;

    void Awake()
    {
        bulletRB = this.gameObject.GetComponent<Rigidbody2D>();
        bulletCol = this.gameObject.GetComponent<Rigidbody2D>();
        enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        enemyCollider = enemyObject.gameObject.GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        this.transform.Translate(bulletSpeed * Time.deltaTime, 0, 0);

        if (bulletCol.IsTouching(enemyCollider) && EnemyScript.health >= 20)
        {
            EnemyScript.health = EnemyScript.health - 20;
            Debug.Log(EnemyScript.health);
            Destroy(this.gameObject);
        }
    }
}
