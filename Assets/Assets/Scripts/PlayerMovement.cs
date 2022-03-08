using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject bulletObject;

    private GameObject player;
    public GameObject floor;

    private Rigidbody2D playerRB;

    public static BoxCollider2D playerCollider;
    public BoxCollider2D floorCollider;

    [SerializeField] GameObject enemyObject;
    public static BoxCollider2D enemyCollider;

    public int playerSpeed;
    public int jumpForce;

    public static bool canJump;

    private float currentTime;
    public float fireRate = 0.1f;

    private bool canShoot;

    public static int score = 0;
    public Text scoreText;

    public bool moveLeft = false;
    public bool moveRight = false;

    void Awake()
    {
        //floor = GameObject.FindGameObjectWithTag("Floor");
        player = GameObject.FindGameObjectWithTag("Player");

        playerRB = player.gameObject.GetComponent<Rigidbody2D>();

        playerCollider = player.gameObject.GetComponent<BoxCollider2D>();
        floorCollider = floor.gameObject.GetComponent<BoxCollider2D>();

        enemyObject = GameObject.FindGameObjectWithTag("Enemy");
        enemyCollider = enemyObject.gameObject.GetComponent<BoxCollider2D>();
    }


    void Update()
    {

        

        currentTime += Time.deltaTime;

        if (currentTime >= fireRate)
        {
            currentTime = 0;
            canShoot = true;
        }


        if (Input.GetKey("d") && moveRight == true)
        {
            playerRB.AddForce(new Vector2(playerSpeed * Time.deltaTime, 0));
        }

        if (Input.GetKeyDown("space"))
        {
            if (canJump == true)
            {
                playerRB.AddForce(new Vector2(0, jumpForce));
            }
        }

        if (Input.GetKey("a") && moveLeft == true)
        {
            playerRB.AddForce(new Vector2(-playerSpeed * Time.deltaTime, 0));
            Debug.Log("a");
        }

        if (Input.GetKey("c"))
        {
            Instantiate(floor);
        }

        if (playerCollider.IsTouching(floorCollider))
        {
            canJump = true;
        }

        else
        {
            canJump = false;
        }
        

        if (Input.GetKey("e") && canShoot)
        {
            Instantiate(bulletObject, player.transform);
            canShoot = false;
            currentTime = 0;
        }

        scoreText.text = score.ToString();

    }

    public void LeftDown()
    {
        moveLeft = true;
    }
    
    public void LeftUp()
    {
        moveLeft = false;
    }

    public void RightDown()
    {
        moveRight = true;
    }

    public void RightUp()
    {
        moveRight = false;
    }

}
