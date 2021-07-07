using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPoint : MonoBehaviour
{
    public GameObject bomb;
    public GameObject bomb2;
    public GameObject[] point;
    int round = 4;
    public static bool bombround = false;
    public static bool bombdrop = false;
    public bool[] PointIndex = new bool[10];
    public int[] Index = new int[10];
    public float timee=0f;

    //public static int[] pointIndex;
    // Start is called before the first frame update
    void Start()
    {
        //pointIndex = new int[4];
        /*for (int i = 0; i < PointIndex.Length; i++)
        {
            PointIndex[i] = false;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (bombround)
        {
            StopAllCoroutines();
            if (round<1)
            {
                round = 1;
            }
            for (int i = 0; i < point.Length; i++)
            {
                point[i].SetActive(false);
                PointIndex[i] = false;
            }
            
            for (int i = 0; i < round; )
            {
                int a = Random.Range(0, point.Length);
                if (PointIndex[a]==false)
                {
                    Index[i] = a;
                    point[a].SetActive(true);
                    PointIndex[a] = true;
                    i++;
                }
            }
            //round--;
            bombround = false;
        }
        if (bombdrop)
        {
            timee += Time.deltaTime;
            if (timee>=3.5f)
            {
                StartCoroutine(BombDrop());
                timee = 0f;
                bombdrop = false;
            }
            
        }
    }
    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());
        for (int i = 0; i < round; i++)
        {
            GameObject newm = Instantiate(m, new Vector2(point[Index[i]].transform.position.x, 3.5f), Quaternion.identity);
            Destroy(newm, 2.5f);
        }

        //round--;
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
    void spawn2(GameObject m)
    {
        //StartCoroutine(Wait());
        for (int i = 0; i < round; i++)
        {
            GameObject newm = Instantiate(m, new Vector2(point[Index[i]].transform.position.x, 6f), Quaternion.identity);
            Destroy(newm, 2.5f);
        }

        round--;
        //Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
    IEnumerator BombDrop()
    {
        spawn(bomb);
        yield return new WaitForSeconds(2f);
        spawn2(bomb2);
    }
}
