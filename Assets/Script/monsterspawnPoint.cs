using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterspawnPoint : MonoBehaviour
{
    public float delayTime;
    public GameObject[] m; //สัตว์ array 
    public GameObject sheep;
    public GameObject slot;
    public GameObject slot_spawn_Pos; //ตำแหน่งเกิดของแกะ
    public GameObject sheep_spawn_Pos; //ตำแหน่งเกิดของสล็อต
    public GameObject[] am;
    GameObject mm;
    int mmm;
    public int a;
    float timee = 0;
    void Start()
    {

    }
    void FixedUpdate()
    {

        timee += Time.deltaTime; //เวลาที่ใช้ในการเรนเดอร์ในแต่ละเฟรม
        if (timee >= delayTime)
        {
            mmm = Random.Range(0, 5); //random เวลาเริ่มแรก
            if (mmm== 2)
            {
                spawnSheep();
            }
            else if (mmm==4)
            {
                spawnSlot();
            }
            else
            {
                a = Random.Range(0, m.Length-1);
                mm = m[a];
                spawn(mm);
            }
            
            //spawn2(mmm);
            timee = 0;
            delayTime = Random.Range(2, 8);
        }


    }

    void spawn(GameObject m) //การออกของสัตว์ตัวอื่นๆ
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);

        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }

    void spawnSheep()
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(sheep, new Vector2(sheep_spawn_Pos.transform.position.x,sheep_spawn_Pos.transform.position.y), Quaternion.identity);
        //newm.SetActive(false);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }

    void spawnSlot()
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(slot, new Vector2(slot_spawn_Pos.transform.position.x, slot_spawn_Pos.transform.position.y), Quaternion.identity);
        //newm.SetActive(false);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }


}    
