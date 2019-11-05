using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D> ();
        speed = 10;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(playerRigidBody.transform.position + tempVect);

        if(Input.GetKeyDown(KeyCode.Space)){
            playerRigidBody.MovePosition(playerRigidBody.transform.position + tempVect * 12);
        }
    }


}
