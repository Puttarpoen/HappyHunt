using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawnLv5 : MonoBehaviour
{
    float timer;
    public GameObject point;
    public GameObject sheep;
    // Start is called before the first frame update
    void Start()
    {
        timer = 12f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 11f)
        {
            spawn(sheep, point);
            timer = 0f;
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
