using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemyParent : MonoBehaviour
{
    public float torqueForce;

    Rigidbody2D rb;
    
    bool addTorque;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        addTorque = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(AudioPeerScript.freqBand[1] > 5f)
        {
            if (addTorque)
            {
                rb.AddTorque(torqueForce);
            }
            
        }

        if(rb.angularVelocity > 75f)
        {
            addTorque = false;
        }

        if(rb.angularVelocity < 50 && !addTorque)
        {
            torqueForce *= -1;
            addTorque = true;
        }

        if (rb.angularVelocity < -75f)
        {
            addTorque = false;
        }

        if (rb.angularVelocity > -50 && !addTorque)
        {
            torqueForce *= -1;
            addTorque = true;
        }

        //Debug.Log(rb.angularVelocity);
    }
}
