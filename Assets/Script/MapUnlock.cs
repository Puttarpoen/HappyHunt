using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUnlock : MonoBehaviour
{
    
    public static bool Stage1;
    public static bool Stage2;
    public static bool Stage3;
    public static bool Stage4;
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Stage1 = false;
        Stage2 = false;
        Stage3 = true;
        Stage4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
