using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cli : MonoBehaviour
{
    public bool isRacePressed = false;
    public bool isbrakePressed = false;

    void Start()
    {

    }

    void Update()
    {
        
    }
    void OnMouseDown()
    {
        cannon.canRot = true;
    }
    void OnMouseUp()
    {
        cannon.canRot = false;
    }
    

}
