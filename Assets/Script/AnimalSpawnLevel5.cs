using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawnLevel5 : MonoBehaviour
{
    public float delayTime;
    int mmm;
    public int a;
    float timee = 0;
    public GameObject[] Animals; //สัตว์ที่เดินออกทางด้านซ้าย
    public GameObject[] Animals_R; //สัตว์ที่เดินออกทางด้านขวา
    public GameObject[] SpawnPoit; //ตำแหน่งเกิด
    public GameObject sheep;
    public GameObject slot;
    static float[] timer;
    float movespeed = 0.5f;
    int direction;
     
    // Start is called before the first frame update
    void Start()
    {
        timer = new float[8];
        for (int i = 0; i < timer.Length; i++)
        {
            timer[i] = 0;
        }
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        timee += Time.deltaTime;
        if (timee >= delayTime)
        {
            mmm = Random.Range(0, SpawnPoit.Length);
          
            if (mmm == 0 && timer[mmm] == 0)
            {
                a = Random.Range(0, Animals.Length);
                //direction = 1;
                spawn(Animals[a], SpawnPoit[mmm]);
                timer[mmm]++;
            }
            else if (mmm == 1 && timer[mmm] == 0)
            {
                a = Random.Range(0, Animals_R.Length);
                spawn(Animals_R[a], SpawnPoit[mmm]);
                timer[mmm]++;
            }
            
            timee = 0;
        }
        for (int i = 0; i < timer.Length; i++)
        {
            if (timer[i]>0)
            {
                timer[i] += Time.deltaTime;
            }
            if(timer[i]>=5f)
            {
                timer[i] = 0;
            }
        }

    }
    void spawn(GameObject m,GameObject point)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(point.transform.position.x, point.transform.position.y), Quaternion.identity);
        
        //Destroy(newm, 13f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
}
