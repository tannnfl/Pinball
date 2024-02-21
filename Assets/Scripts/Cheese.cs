using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    Rigidbody2D ballrb;
    public float emitForce;
    void Start()
    {
        ballrb = GameObject.Find("ball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ballrb.AddForce(new Vector3(0,emitForce,0));
    }
}
