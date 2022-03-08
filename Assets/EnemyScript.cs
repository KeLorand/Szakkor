using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public static float health = 100;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (health <= 0)
        {
            PlayerMovement.score += 10;
            Destroy(this.gameObject);
        }
    }
}
