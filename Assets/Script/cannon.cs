using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cannon : MonoBehaviour
{
    public static bool canRot;
    FollowBullet follow = new FollowBullet();
    Timer timee = new Timer();
    public AudioSource SoundCannon;
    public GameObject ball;
    public float launchForce;
    public Transform shotPoint; //ตำแหน่งการเกิดจุด
    public Text angel_Text; //โชว์ค่า องศาของปืน
    public Text Force_Text; //โชว์ค่า ความเร็วเริ่มต้น 
    public Text ammo_Text; //โชว์จำนวนกระสุน
    public Text Forcex; //โชว์ค่า ความเร็วเริ่มต้น 
    public Text sin; 
    public Text cos;
    public Text S; 
    public GameObject boombPos; //ตำแหน่งที่เกิดเอฟเฟคระเบิด
    public GameObject boomb; //ใส่เอฟเฟกระเบิด
    public int ammo;

    public GameObject point;
    GameObject[] points;
    public int numberOfPoint;
    public float spaceBetweenPoints;
    Vector2 direction; //เส้นทาง

    

    private void Start()
    {
        
        points = new GameObject[numberOfPoint];
        for (int i = 0; i<numberOfPoint; i++)
        {
            points[i] = Instantiate(point, shotPoint.position, Quaternion.identity); // โชว์เส้นไกด์ระยะในการยิ่ง
        }


    }
    void Update()
    {
        Vector2 cannonPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 

        if (FollowBullet.shooting == false && Timer.stopTimer == false &&canRot==true)
        {
            direction = mousePosition - cannonPosition;
            transform.right = direction;
            

        }
        for (int i = 0; i<numberOfPoint; i++)
        {
            points[i].transform.position = PointPosition(i * spaceBetweenPoints); //เส้นระยะทาง
            //spaceBetweenPoints คือ ระยะห่างระหว่างจุด 
            //numberOfPoint จำนวนจุด 

        }

        int tem_angless = (int)Mathf.Abs(180 - transform.rotation.eulerAngles.z);//180-เพื่อให้ค่าไม่เกิน180 
        //Mathf.Abs ทำให้ค่าองศาไม่ติดลบ

        float angless = tem_angless * Mathf.PI / 180; //Mathf.PI มาหารเพื่อแปลงหน่วย เรเดียนเป็นองศา


        angel_Text.text = tem_angless.ToString(); 
        sin.text = tem_angless.ToString(); 
        cos.text = tem_angless.ToString();


        Forcex.text = launchForce.ToString("f2");
        Force_Text.text = launchForce.ToString("F2");
        ammo_Text.text = ammo.ToString("F0"); //โชว์จำนวนกระสุน 

        
        float m = 2* launchForce * launchForce * Mathf.Sin(angless)* Mathf.Cos(angless)/10; //การคำนวณสูตร 
        S.text = m.ToString("f2"); 

    }
    void Shoot() //การปล่อยกระสุน
    {
        
        
            GameObject newBall = Instantiate(ball, shotPoint.position, shotPoint.rotation);
            newBall.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
            GameObject newG =Instantiate(boomb, new Vector2(boombPos.transform.position.x, boombPos.transform.position.y), Quaternion.identity);
            Destroy(newG, 2);
            Destroy(newBall, 2);
        
        
    }
    Vector2 PointPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
        //การทำให้เส้นระยะทางเป็นเส้น

    }

    public void ForceSetting(float newForce)
    {
        launchForce = newForce; // เป็นค่า u
    }

    public void Fire() 
    {
        if (ammo > 0 && FollowBullet.shooting == false && Timer.stopTimer == false && Time.timeScale == 1)
            
        {
            if (canRot == false)
            {
                FollowBullet.shooting = true;
                SoundCannon.Play();
                Shoot();
                ammo--;
            }
            

        }
    }
    
}
