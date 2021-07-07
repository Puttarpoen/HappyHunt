using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertCore : MonoBehaviour
{
    public static AlertCore instance { get; private set; }

    public GameObject alertObj;
    public Text msgText;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetAlert(string msg)
    {
        alertObj.SetActive(true);
        msgText.text = msg;
    }

}
