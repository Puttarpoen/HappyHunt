using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwhook : MonoBehaviour
{
    public GameObject hook;

    GameObject curHook;

    public bool ropeActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void rope()
    {

        if (ropeActive == false)
        {
            Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
            curHook.GetComponent<RopeScript>().destiny = destiny;
            ropeActive = true;
        }
        else
        {

            //delete rope

            Destroy(curHook);


            ropeActive = false;

        }
    }

    void Update()
    {
       
    }
}
