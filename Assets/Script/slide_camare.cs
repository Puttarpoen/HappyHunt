using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slide_camare : MonoBehaviour
{
    void Start()
    {

    }


    void Update()
    {
        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0f, 0, -10f);
        }

    }

    public void Left()
    {

        if (transform.position.x > 0f && FollowBullet.shooting == false)
        {
            StartCoroutine(ExampleCoroutine());
        }
    }
    public void LeftEnd()
    {
        StopAllCoroutines();
    }
    public void Right()
    {
        if (transform.position.x < 13.8f && FollowBullet.shooting == false)
        {
            StartCoroutine(Rightslide());
        }
    }
    public void RightEnd()
    {
        StopAllCoroutines();
    }
    IEnumerator ExampleCoroutine()
    {

        for (; transform.position.x > 0f;)
        {
            transform.Translate(Vector3.right * -1 * 5 * Time.fixedDeltaTime);
            yield return new WaitForSecondsRealtime(0.0025f);
        }

    }


    IEnumerator Rightslide()
    {
        for (; transform.position.x < 13.8f;)
        {
            transform.Translate(Vector3.right * 1 * 5 * Time.fixedDeltaTime);
            yield return new WaitForSecondsRealtime(0.0025f);
        }
    }
}
