using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    //Variables for the Blink cooldown
    public static double blinkCooldown;
    private bool startBlinkCooldown;

    //Speed variable that can be accessed from the Inspector
    public float speed;

    //Components on the player 
    private Rigidbody2D playerRigidBody;
    private BoxCollider2D boxCollider;

    //Variables for the Blink move
    private double blinkTime;
    private bool isBlinking;
    private bool canBlink;


    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        boxCollider = this.GetComponent<BoxCollider2D>();
        playerRigidBody.bodyType = RigidbodyType2D.Kinematic;
        isBlinking = false;
        canBlink = true;
        blinkTime = .15;
        speed = 15;
        startBlinkCooldown = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(canBlink){
                if(blinkCooldown <= 0){
                    canBlink = !canBlink;
                    isBlinking = !isBlinking;
                    boxCollider.enabled = !boxCollider.enabled;
                    startBlinkCooldown = true;
                    blinkCooldown = 3;
                }
            }
        }
    }

    void FixedUpdate()
    {
        //Get player input
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
 
        //Player movement
        Vector3 temperaryVector = new Vector3(horizontalMovement, verticalMovement, 0);
        temperaryVector = temperaryVector.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(playerRigidBody.transform.position + temperaryVector);

        //If player can blink, turn up the speed
        if(isBlinking){
            blinkTime = blinkTime - Time.deltaTime;
            if(blinkTime > 0){
                speed = 33;
            }else{
                speed = 15;
                blinkTime = .15;
                isBlinking = !isBlinking;
                canBlink = !canBlink;
                boxCollider.enabled = !boxCollider.enabled;
            }
        }

        //If space button is pressed, start the blink cooldown
        if(startBlinkCooldown){
            blinkCooldown -= Time.deltaTime;
            if(blinkCooldown <= 0){
                startBlinkCooldown = false;
            }
        }

    }

}
