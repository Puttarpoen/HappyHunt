using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBullet : MonoBehaviour
{
    public static bool shooting;
    
    // Start is called before the first frame update
    void Start()
    {
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] Bullet;
        Bullet = GameObject.FindGameObjectsWithTag("ball");
        if (Bullet.Length != 0&& Bullet[0].transform.position.x <= 0f&& Bullet[0].transform.position.x>=-13.4)
        {
            transform.position=new Vector3(Bullet[0].transform.position.x,0,-10);
            shooting = true;
        }
        if (Bullet.Length == 0)
        {
            //transform.position = new Vector3(0f, 0f, -10f);
            shooting = false;
        }
    }
}
