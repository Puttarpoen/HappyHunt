using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumControll : MonoBehaviour
{
    public GameObject MM;
    public GameObject Point;
    public static bool canmove;
    // Start is called before the first frame update
    void Start()
    {
        canmove = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Point.transform.position.x, Point.transform.position.y, Point.transform.position.z);

       
        
        

    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="han" )
        {
           
            transform.Translate(-Vector3.up * Time.fixedDeltaTime * 10);
            Debug.Log("MMMMMMMM");
        }
        else
        {
            Debug.Log("WWWW");
        }
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "han")
        {
            transform.Translate(-Vector3.up * Time.fixedDeltaTime * 10);
            Debug.Log("MMMMMMMM");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "han")
        {
            transform.Translate(-Vector3.up * Time.fixedDeltaTime * 10);
            Debug.Log("MMMMMMMM");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "han")
        {
            canmove = false;
            transform.Translate(-Vector3.up * Time.fixedDeltaTime * 10);
            Debug.Log("MMMMMMMM");
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "han")
        {
            MM.transform.Translate(-Vector3.up * 1000f);
            Debug.Log("MMMMMMMM");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hand")
        {
            transform.position += new Vector3(0, 1f, 0);
            Debug.Log("MMMMMMMM");
        }
    }*/
}
