using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamBar : MonoBehaviour
{
    public int band;
    public float startScale, scaleMultiplier;

    public GameObject movingObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(transform.localScale.x, (AudioPeerScript.freqBand[band] * scaleMultiplier) + startScale, transform.localScale.z);

        CreateMovingObject();
    }

    void CreateMovingObject()
    {
        if(transform.localScale.y > 10f)
        {
            Instantiate(movingObject, transform.position, Quaternion.identity);
        }
    }
}
