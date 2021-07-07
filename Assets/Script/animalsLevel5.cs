using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalsLevel5 : MonoBehaviour
{
    public int ani_score;
    public int helth;
    public GameObject blood;
    public GameObject m;
    public float direction;
    //float moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        transform.Translate(Vector3.right * Time.deltaTime*direction);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "han")
        {
            helth--;
            spawn(blood);
            if (helth <= 1 && helth > 0)
            {

                if (gameObject.tag != "no" && gameObject.tag != "sheepfall")
                {
                    spawn(m);
                }
                spawn(blood);
                Destroy(gameObject);

            }
            else if (helth <= 0)
            {

                ScoreManager.total_score += ani_score;
                spawn(blood);
                Destroy(gameObject, 0.25f);

            }
            
            //Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "deadline")
            Destroy(gameObject);
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "ground2")
        {
            transform.position = transform.position + new Vector3(0f, 0.1f, 0f);
        }
    }*/
    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        
            Destroy(newm, 2);


    }
}
