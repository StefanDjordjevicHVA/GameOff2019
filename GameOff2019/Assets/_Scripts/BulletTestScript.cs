using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTestScript : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    public int life = 75;

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;

        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;

        life--;

        if (life < 0) Destroy(this.gameObject);
    }

    //void OnParticleCollision(GameObject other)
    //{
    //    int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

    //    ParticleSystem partOther = other.GetComponentInChildren<ParticleSystem>();
    //    int i = 0;

    //    while (i < numCollisionEvents)
    //    {
    //        if(partOther != null)
    //        {
    //            Debug.Log("It's There");
    //            partOther.emissionRate++;
    //        }
    //    }
    //}
}
