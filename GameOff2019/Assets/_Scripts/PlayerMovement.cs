using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private double blinkTime;
    private Rigidbody2D playerRigidBody;

    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        speed = 10;
        blinkTime = 0.2;
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 tempVect = new Vector3(h, v, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(playerRigidBody.transform.position + tempVect);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // playerRigidBody.MovePosition(playerRigidBody.transform.position + tempVect * 12);
            StartCoroutine(Blink());
            StopCoroutine(Blink());
        }

        if (blinkTime <= 0)
        {
            speed = 10;
            blinkTime = 0.2;
        }

    }

    IEnumerator Blink()
    {
        while (blinkTime > 0)
        {
            blinkTime -= Time.deltaTime;
            speed = 40;
            yield return null;
        }
    }

}