using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestMovement : MonoBehaviour
{
    Rigidbody2D rb;
    MeshRenderer rend;

    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveOnBand();
    }

    void MoveOnBand()
    {
        if (AudioPeerScript.freqBand[6] > 5f) transform.Rotate(new Vector3(0, 0, 20f));

        if (AudioPeerScript.freqBand[0] > 1f)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1);

            float rotate = 90f;

            for (int i = 0; i < 4; i++)
            {
                GameObject obj = Instantiate(bullet);
               
                obj.transform.position = transform.position;
                obj.transform.rotation = transform.rotation;
                obj.transform.Rotate(new Vector3(0, 0, rotate * i));
            }
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }


}
