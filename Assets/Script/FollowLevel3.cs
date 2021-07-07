using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLevel3 : MonoBehaviour
{
    public static bool shooting;
    float timee;
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
        timee = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Bullet;
        Bullet = GameObject.FindGameObjectsWithTag("animals");
        if (Bullet.Length != 0 && Bullet[0].transform.position.x >= 0f && Bullet[0].transform.position.x <= 13.4)
        {
            transform.position = new Vector3(Bullet[0].transform.position.x, 0, -10);
            shooting = true;
        }
        if (Bullet.Length == 0)
        {
            StartCoroutine(ExampleCoroutine());
        }

    }
    IEnumerator ExampleCoroutine()
    {
        

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2.5f);
        transform.position = new Vector3(0f, 0f, -10f);
        shooting = false;

    }
}
