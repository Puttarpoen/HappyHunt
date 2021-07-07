using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{

    public bool hooking = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody2D>().AddForce(Vector2.left*180);

        if(hooking==true)
        {
            transform.Translate(-Vector3.up * Time.fixedDeltaTime);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="animals")
        {
            transform.SetParent(collision.gameObject.transform);
            hooking = false;
        }
        else if (collision.gameObject.tag=="ground")
        {
            hooking = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            hooking = false;
        }
    }
    public void rotate()
    {
        StartCoroutine(Rightslide());
    }
    public void RightEnd()
    {
        StopAllCoroutines();
    }
    IEnumerator Rightslide()
    {
        for (;;)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * 180);
            yield return new WaitForSecondsRealtime(0.0025f);
        }
    }
    public void Hook()
    {
       
        hooking = true;
    }
}
