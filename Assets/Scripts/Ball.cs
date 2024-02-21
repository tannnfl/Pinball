using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public KeyCode keyEmit;
    public KeyCode restartGame;
    public float emitForce;
    int score;
    bool canEmit = true;
    int lifes = 3;
    Transform startPoint;
    Transform endPoint;

    GameObject pineapple;
    GameObject onion;
    GameObject salami;
    GameObject mushroom;
    GameObject cheese;

    AudioSource sfxemit;
    AudioSource sfxlose;
    AudioSource sfxhitgood;
    AudioSource sfxhitbad;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPoint = GameObject.Find("StartingPoint").GetComponent<Transform>();
        endPoint = GameObject.Find("EndingPoint").GetComponent<Transform>();

        pineapple = GameObject.Find("Pineapple");
        onion = GameObject.Find("Onion");
        salami = GameObject.Find("bummer");
        mushroom = GameObject.Find("Mushroom");
        cheese = GameObject.Find("Cheese");

        sfxemit = this.GetComponent<AudioSource>();
        sfxlose = GameObject.Find("EndingPoint").GetComponent<AudioSource>();
        sfxhitgood = GameObject.Find("Mushroom").GetComponent<AudioSource>();
        sfxhitbad = GameObject.Find("Pineapple").GetComponent<AudioSource>();
    }

    void Update()
    {
        //emit
        if (Input.GetKeyDown(keyEmit) && canEmit)
        {
            if (!sfxemit.isPlaying)
            {
                sfxemit.Play();
            }
            rb.AddForce(new Vector2(0, emitForce), ForceMode2D.Force);
            canEmit = false;
        }
        //Restart
        if (Input.GetKeyDown(restartGame)){
            RestartGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == startPoint.gameObject)
        {
            canEmit = true;
        }
        //Respawn
        if (collision.gameObject == endPoint.gameObject)
        {
            if (!sfxlose.isPlaying)
            {
                sfxlose.Play();
            }
            if (lifes > 0)
            {
                lifes--;
                transform.position = startPoint.position; 
            }
            //Gameover
            else if (lifes <= 0)
            {
                RestartGame();
            }
        }

        //Collision and score
        if(collision.gameObject == pineapple)
        {
            sfxhitbad.Play();
            AddScore(-3);
        }
        if(collision.gameObject == onion)
        {
            sfxhitgood.Play();
            AddScore(10);
        }
        if (collision.gameObject == mushroom)
        {
            sfxhitgood.Play();
            AddScore(2);
        }
        if (collision.gameObject == cheese)
        {
            sfxhitgood.Play();
            AddScore(15);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == salami)
        {
            sfxhitgood.Play();
            AddScore(4);
        }
    }

    //functions
    public void AddScore (int a)
    {
        score += a;
    }
    public int Score()
    {
        return score;
    }
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
