using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate512Bars : MonoBehaviour
{
    public GameObject sampleBarPrefab;
    public float maxScale;

    private GameObject[] sampleBar = new GameObject[512];

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 512; i++)
        {
            GameObject _instantiateBar = (GameObject)Instantiate(sampleBarPrefab);
            // -8.84, -5
            // + .9f op de x-as
            //_instantiateBar.transform.position = new Vector2(-8.84f, -5f);
            //_instantiateBar.transform.parent = this.transform;
            //_instantiateBar.name = "Samplebar" + i;
            //_instantiateBar.transform.position += new Vector3(0.11f * i, 0, 0);

            _instantiateBar.transform.position = this.transform.position;
            _instantiateBar.transform.parent = this.transform;
            _instantiateBar.name = "Samplebar" + i;
            this.transform.eulerAngles = new Vector3(0, 0, 0.703125f * i);
            _instantiateBar.transform.position = Vector3.up * 1.5f;

            sampleBar[i] = _instantiateBar;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < 512; i++)
        {
            if(sampleBar != null)
            {
                sampleBar[i].transform.localScale = new Vector3(0.1f, (AudioPeerScript.samples[i] * maxScale) + 0.1f, 1);
            }
        }
    }
}
