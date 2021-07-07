using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAt : MonoBehaviour
{
    public GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.transform.position;
        Vector3 targetPosFlattened = new Vector3(targetPos.x, targetPos.y, 0);
        transform.LookAt(targetPosFlattened);
    }
}
