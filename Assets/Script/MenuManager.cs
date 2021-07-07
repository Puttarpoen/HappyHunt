using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class MenuManager : MonoBehaviour
{

    public GameObject m;
    public GameObject m2;
    
    public GameObject B2;
    public GameObject B3;
    public GameObject B4;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        var gs = GameService.instance;
        if (gs.user.stages.Length > 0 && B2)
        {
            Debug.Log(gs.user.stages.Length);
            var listStage = gs.user.stages.ToList();
            if (listStage.Contains(1))
            {
                B2.SetActive(true);
            }
            if (listStage.Contains(2))
            {
                B3.SetActive(true);
            }
            if (listStage.Contains(3))
            {
                B4.SetActive(true);
            }
        }
    }


    // Update is called once per frame
    //void Update()
    //{
    //    if (MapUnlock.Stage1 == true)
    //    { B2.SetActive(true); Debug.Log(MapUnlock.Stage1); }
    //    if (MapUnlock.Stage2 == true)
    //    { B3.SetActive(true); Debug.Log(MapUnlock.Stage2); }
    //    if (MapUnlock.Stage4 == true)
    //    { B4.SetActive(true);
    //    Debug.Log(MapUnlock.Stage4);
    //    }
        

    //}
    public void Onpause()
    {
        Time.timeScale = 0;
        m.SetActive(false);
        m2.SetActive(true);
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        m.SetActive(true);
        m2.SetActive(false);
    }

    public void LoadLevel1()
    {
        GameManager.newGame = true;
        FollowBullet.shooting = false;
        Timer.stopTimer = false;
        ScoreManager.total_score = 0;
        SceneManager.LoadScene("Onelevel");
        //Application.LoadLevel("Onelevel");
    }
    public void LoadMap()
    {

        SceneManager.LoadScene("Map");

    }
    public void LoadSignIN()
    {

        SceneManager.LoadScene("SignIn_Signup");

    }
    public void LoadLevel2()
    {
        GameManager.newGame = true;
        FollowBullet.shooting = false;
        Timer.stopTimer = false;
        ScoreManager.total_score = 0;
        SceneManager.LoadScene("Level_2");
    }

    public void LoadLevel3()
    {
        GameManager.newGame = true;
        FollowBullet.shooting = false;
        Timer.stopTimer = false;
        ScoreManager.total_score = 0;
        SceneManager.LoadScene("level_3");
    }
    public void LoadLevel4()
    {
        GameManager.newGame = true;
        FollowBullet.shooting = false;
        Timer.stopTimer = false;
        ScoreManager.total_score = 0;
        SceneManager.LoadScene("level_5");
    }
    
}
