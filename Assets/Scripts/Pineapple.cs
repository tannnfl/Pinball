using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pineapple : MonoBehaviour
{
    Rigidbody2D ballrb;
    public float emitForce;

    void Start()
    {
        ballrb = GameObject.Find("ball").GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ballrb.AddForce(new Vector2(0, emitForce), ForceMode2D.Force);
    }
}
