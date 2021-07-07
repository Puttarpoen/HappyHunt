using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalLevel3 : MonoBehaviour
{
    //aniSpawnLevel3 a;
    public AudioSource impact;
    public AudioSource impact2;
    //AudioSource audioSource;
    public GameObject blood;
    public GameObject blood2;
    //public GameObject particle_1;
    public int helth;
    public int ani_score;
    //bool Moveright = true;
    //int anitag;
    public GameObject m;
    //bool shooting = false;
    // Start is called before the first frame update
    void Start()
    {
        impact = GameObject.Find("impact").GetComponent<AudioSource>();
        impact2 = GameObject.Find("impact2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
           

            Destroy(collision.gameObject);
            helth -= 100;
            spawn(blood);
            if (helth<=0)
            {
                ScoreManager.total_score += ani_score;
                spawn(blood);
                Destroy(collision.gameObject);
                Destroy(gameObject, 0.15f);
            }
            

            //}



        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {

            
            Destroy(collision.gameObject);
            helth -= 100;
            if (helth <= 100 && helth > 0)
            {

                if (gameObject.tag != "no")
                {
                    spawn(m);
                }
                impact.Play();
                spawn(blood2);
                Destroy(gameObject);

            }
            //spawn(blood2);
            if (helth <=   0)

            {
                impact2.Play();
                ScoreManager.total_score += ani_score;
                spawn(blood);
                Destroy(collision.gameObject);
                Destroy(gameObject, 0.15f);
            }
            



        }
    }
    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        if (m == blood||m==blood2)
        {
            Destroy(newm, 2);
        }
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
    
}
