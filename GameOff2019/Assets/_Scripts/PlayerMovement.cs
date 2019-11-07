using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private double blinkTime;
    private Rigidbody2D playerRigidBody;
    private bool isBlinking;
    private bool canBlink;

    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        isBlinking = false;
        canBlink = true;
        blinkTime = .1;
        speed = 10;
    }

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space)){
             if(canBlink){
                 canBlink = !canBlink;
                 isBlinking = !isBlinking;
             }
        }
    }

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
 
        Vector3 temperaryVector = new Vector3(horizontalMovement, verticalMovement, 0);
        temperaryVector = temperaryVector.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(playerRigidBody.transform.position + temperaryVector);

        if(isBlinking){
            blinkTime = blinkTime - Time.deltaTime;
            if(blinkTime > 0){
                speed = 25;
            }else{
                speed = 10;
                blinkTime = .1;
                isBlinking = !isBlinking;
                canBlink = !canBlink;
            }
        }

    }

}
