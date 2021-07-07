using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSpawnLv5 : MonoBehaviour
{
    float timer;
    public GameObject point;
    public GameObject slot;
    // Start is called before the first frame update
    void Start()
    {
      timer=16f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        timer+=Time.deltaTime;
        if (timer>=15f)
        {
            spawn(slot,point);
            timer=0f;
        }
    }
    void spawn(GameObject m, GameObject point)
    {
        //StartCoroutine(Wait());

        GameObject newm = Instantiate(m, new Vector2(point.transform.position.x, point.transform.position.y), Quaternion.identity);

        //Destroy(newm, 5f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }
}
