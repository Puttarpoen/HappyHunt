using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn2 : MonoBehaviour
{
    public float delayTime;
    public GameObject[] m;

    //public GameObject[] am;
    GameObject mm;
    int mmm;
    public int a;
    float timee = 0;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timee += Time.deltaTime;
        if (timee >= delayTime)
        {
            a = Random.Range(0, m.Length-1);
            mm = m[a];
            spawn(mm);
            //spawn2(mmm);
            timee = 0;
            delayTime = Random.Range(2, 8);
        }


    }

    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }

    
}
