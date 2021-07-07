using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public class animal : MonoBehaviour
{
    public AudioClip impact;
    AudioSource audioSource;
    public GameObject blood;//
    public GameObject particle_1; //เอฟเฟคตอนโดนยิง
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
        if (collision.gameObject.tag == "ball")
        {
            //if (anitag <= 10)
            audioSource.PlayOneShot(impact, 1.0F);
            GameObject newPar=Instantiate(particle_1, new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y), Quaternion.identity);
            Destroy(newPar, 2);
            Destroy(collision.gameObject);
            helth -= 100;
            if (helth<=100&&helth>0)
            {
                
                if (gameObject.tag != "no"&&gameObject.tag!="sheepfall")
                {
                    spawn(m);
                }
                spawn(blood);
                Destroy(gameObject);

            }
            else if(helth<=0)
            {
                
                ScoreManager.total_score += ani_score;
                spawn(blood);
                Destroy(gameObject,0.25f);

            }
            
           
            
        }
        else if (gameObject.tag=="slot"&&collision.gameObject.tag=="deadline")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag=="deadline")
        {
            ScoreManager.total_score -= 10;
            Destroy(gameObject);
        }
        else if (gameObject.tag == "sheepfall" && collision.gameObject.tag == "ground")
        {
            ScoreManager.total_score += ani_score;
            spawn(blood);
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag=="sheepfall")
        {
            ScoreManager.total_score += ani_score;
            Destroy(gameObject);
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag=="ground")
        {
            ScoreManager.total_score += ani_score;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground"|| collision.gameObject.tag == "ground2")
        {
            transform.position = transform.position + new Vector3(0f, 0.1f, 0f);
        }
    }

    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        if (m==blood)
        {
            Destroy(newm, 2);
        }
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
}
