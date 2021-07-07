using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aniSpawnLevel3 : MonoBehaviour
{
    public AudioSource shootsound;
    public GameObject[] animals;
    public GameObject spawnPoint;
    public Text forceText;
    public Text U_Text;
    public Text S_Text;
    public float force;
    GameObject newm;
    float timee;
    public float delayTime;
    int m;
    bool canSpawn=true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //timee += Time.deltaTime;
        if (newm==null)
        {
            /*BombPoint.bombround = true;
            m = Random.Range(0, animals.Length);
            spawn(animals[m]);
            //canSpawn = false;
            //spawn2(mmm);
            //timee = 0;
            //delayTime = Random.Range(2, 8);*/
            StartCoroutine(ExampleCoroutine());
        }

        forceText.text = force.ToString("f2");
        U_Text.text = force.ToString("f2");

        float uu = force * force;
        float s = uu / 2;
        S_Text.text = s.ToString("f2");
    }

    void spawn(GameObject m)
    {
        //StartCoroutine(Wait());
        StopAllCoroutines();
        newm = Instantiate(m, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
        //Destroy(newm, 5f);
        Debug.Log("Started Coroutine at timestamp : " + Time.time);


    }

    public void shoot()
    {
        if (newm!=null)
        {
            newm.GetComponent<Rigidbody2D>().velocity = transform.right * force * 1.5f;
            shootsound.Play();  
            BombPoint.bombdrop = true;
            Destroy(newm, 7.5f);
        }
    }
    public void ForceSetting(float newForce)
    {
        force = newForce; // เป็นค่าความเร็วเริ่มต้นที่กำหนดไว้ในหน้า unity โดยจะกำหนดค่าเริ่มต้นที่ 1 m/s 
    }
    IEnumerator ExampleCoroutine()
    {
        

        
        yield return new WaitForSeconds(3);

        BombPoint.bombround = true;
        m = Random.Range(0, animals.Length);
        spawn(animals[m]);

    }
}
