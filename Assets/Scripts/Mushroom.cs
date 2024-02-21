using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    Rigidbody2D ballrb;
    public float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        ballrb = GameObject.Find("ball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ballrb.velocity += ballrb.velocity.normalized * acceleration * Time.deltaTime;
    }
}
