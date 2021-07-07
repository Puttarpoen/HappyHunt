using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class Ani : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;
    public GameObject blood;
    public GameObject particle_1;
    Timer timee = new Timer();
    //static float times;
    float dirX, moveSpeed = 0.5f;
    public int helth;
    public int ani_score;
    bool Moveright = true;
    int anitag;
    public GameObject m;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 4f)
        {
            Moveright = true;
        }

        if (Moveright && Timer.stopTimer == false)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
    private void FixedUpdate()
    {


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "animals")
        {
            ScoreManager.total_score += collision.gameObject.GetComponent<animal>().ani_score ;
            spawn(blood);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ground")
        {
            spawn(blood);
            Destroy(gameObject);
        }

    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //    if (collision.gameObject.tag == "ground")
    //    {
            
    //        spawn(blood);
    //        Destroy(gameObject);
    //    }
        
    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground2"&&gameObject.tag!= "anifalling")
        {
            transform.position = transform.position + new Vector3(0f, 0.1f, 0f);
        }
        else if(collision.gameObject.tag=="Bombb")
        {
            if(gameObject.tag=="anifall")
            {
                ScoreManager.total_score += ani_score;
                spawn(blood);
                Destroy(collision.gameObject);
                spawn(m);
                Destroy(gameObject);
            }
        
            else
            {
                ScoreManager.total_score += ani_score;
                spawn(blood);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            
        }
        else if (collision.gameObject.tag == "deadline")
        {
            ScoreManager.total_score -= 10;
            Destroy(gameObject);
        }
    }

    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        if (m == blood)
        {
            Destroy(newm, 2);
        }
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
}

