using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HandControl : MonoBehaviour
{
    public Text L_Text;
    public Text LL_Text;
    public Text T_Text;
    public GameObject Hand;
    public GameObject Origin;
    public GameObject P;
    public static float I;
    float N;
    bool move2;
    bool move;
    bool highest;
    float timee=0f;
    // Start is called before the first frame update
    void Start()
    {
        I = 1f;
        N = 1f;
        move2 = false;
        move = false;
        highest = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        L_Text.text = I.ToString();
        LL_Text.text = I.ToString("F1");
        float squ = Mathf.Sqrt(I);
        float sq = squ / 10;
        float T = 2 * 3.14f * sq;
        T_Text.text = T.ToString("F1");
    }

    private void FixedUpdate()
    {

        if (move)
        {
            if (N < I && highest == false)
            {
                N += 0.1f;
                transform.localScale = new Vector3(Hand.transform.localScale.x, N, Hand.transform.localScale.z);
                if (N>=I)
                {
                    
                    highest = true;
                    move2 = true;
                    Debug.Log(Pendulum.velocityThreshold);
                    Debug.Log("MMMMMMMM");
                }
            }
            else if (highest==true)
            {
                //Pendulum.velocityThreshold = 120f;
                timee += Time.deltaTime;
                // StartCoroutine(ExampleCoroutine());
                
                //Pendulum.velocityThreshold = 120f;
                
                
                if (timee>=3f)
                {
                    //Pendulum.velocityThreshold = 0f;
                    move2 = false;
                    N -= 0.1f;
                    transform.localScale = new Vector3(Hand.transform.localScale.x, N, Hand.transform.localScale.z);
                }
                
                if (N<=0.7&&timee>=3f)
                {
                    //Pendulum.velocityThreshold = 0f;
                    timee = 0f;
                    highest = false;
                    move = false;
                }

            }
    
        }
    }

    public void ISetting(float newI)
    {
        //if(!move)
        I = newI;
        

    }

    public void MoveOn()
    {
        move = true;
    }

    public void NotMove()
    {
        move = false;
    }

    

}
