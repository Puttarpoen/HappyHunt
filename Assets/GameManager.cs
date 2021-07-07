using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static bool newGame;
    public GameObject Win;
    public GameObject lose;
    public GameObject[] Dao;
    Timer timee = new Timer();
    float time;
    int score;
    bool isSaveGame = false;
    // Start is called before the first frame update
    void Start()
    {
        newGame = false;
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScoreManager.total_score = Random.Range(2550, 9999);
            Timer.stopTimer = true;
        }

        if(newGame==true)
        {
            Time.timeScale = 1;
        }
        if(Timer.stopTimer==true && !isSaveGame)
        {
            var gs = GameService.instance;
            Time.timeScale = 0;
            if (ScoreManager.total_score>=2000)
            {

                Win.SetActive(true);
                //if(time==2f)
          
                Dao[0].SetActive(true);
                if(ScoreManager.total_score>=2500)
                {
                    Dao[1].SetActive(true);
                    if (SceneManager.GetActiveScene().name=="Onelevel")
                    {
                        gs.AddStage(1);
                        AddStage(1);
                        MapUnlock.Stage1 = true;
                    }
                    else if (SceneManager.GetActiveScene().name == "Level_2")
                    {
                        gs.AddStage(2);
                        AddStage(2);
                        MapUnlock.Stage2 = true;
                    }
                    else if (SceneManager.GetActiveScene().name == "level_3")
                    {
                        gs.AddStage(3);
                        AddStage(3);
                        MapUnlock.Stage4 = true;
                    }
                    else if (SceneManager.GetActiveScene().name == "level_5")
                    {
                        gs.AddStage(4);
                        AddStage(4);
                        MapUnlock.Stage4 = true;
                    }

                }
               
                if(ScoreManager.total_score>=3000)
                Dao[2].SetActive(true);

            }
            else if (ScoreManager.total_score < 2000)
            { lose.SetActive(true); }


            if (SceneManager.GetActiveScene().name == "Onelevel")
            {
                gs.AddScore(ScoreManager.total_score,1);
            }
            else if (SceneManager.GetActiveScene().name == "Level_2")
            {
                gs.AddScore(ScoreManager.total_score,2);
            }
            else if (SceneManager.GetActiveScene().name == "level_3")
            {
                gs.AddScore(ScoreManager.total_score,3);
            }
            else if (SceneManager.GetActiveScene().name == "level_5")
            {
                gs.AddScore(ScoreManager.total_score,4);
            }
            isSaveGame = true;
        }
    }

    private void FixedUpdate()
    {
        if (Timer.stopTimer == true)
            time = Time.time - timee.gameTime;
    }

    private void AddStage(int stage)
    {
        if(GameService.instance.user.stages.Length > 0)
        {
            if (!GameService.instance.user.stages.ToList().Contains(stage))
            {
                Array.Resize(ref GameService.instance.user.stages, GameService.instance.user.stages.Length + 1);
                GameService.instance.user.stages[GameService.instance.user.stages.Length - 1] = stage;
            }   
        }
    }

}
