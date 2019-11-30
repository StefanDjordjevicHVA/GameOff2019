using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(BoxCollider2D))]

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private double blinkTime;
    private Rigidbody2D playerRigidBody;

    private int particlesHit;

    public GameObject powerShotObject;

    public ParticleSystem part;
    public ParticleSystem part2;

    public List<ParticleCollisionEvent> collisionEvents;


    void Start()
    {
        playerRigidBody = this.GetComponent<Rigidbody2D>();
        speed = 10;
        blinkTime = 0.2;

        particlesHit = 0;
    }

    void FixedUpdate()
    {
        RotatePowerShot();
        AddParticlesToPowerShot();

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

    void RotatePowerShot()
    {
        powerShotObject.transform.Rotate(new Vector3(0, 0, 5f));
    }

    void AddParticlesToPowerShot()
    {
        //part.emissionRate++;
    }

    void OnParticleCollision(GameObject other)
    {
        if (particlesHit > 20)
        {
            if (part.emissionRate > 1000)
            {
                part.emissionRate = 1000;
                part2.emissionRate = 1000;
            }
            part.emissionRate++;
            part2.emissionRate++;
            particlesHit = 0;
        }
        particlesHit++;
    }

}