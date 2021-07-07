using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int total_score;
    public Text m;
    public Text m2;
    public Text m3;
    // Start is called before the first frame update
    void Start()
    {
        total_score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        m.text = total_score.ToString("F0");
        m2.text = total_score.ToString("F0");
        m3.text = total_score.ToString("F0");
    }
}
