using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class User
{
    public string id;
    public string username;
    public string email;
    public HighScore[] hight_score_game;
    public int[] stages;
}

[System.Serializable]
public class HighScore
{
    public int score;
    public string stage_id;
}
[System.Serializable]
public class RankingScore
{
    public string username;
    public int score;
}

public class GameService : MonoBehaviour
{
    public static GameService instance { get; private set; }
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

    public string endpoint = "localhost:8080/happy_hunt/";

    [Header("Data")]
    public User user;

    public void Login(string email, string password)
    {
        StartCoroutine(_Login(email, password));
    }

    IEnumerator _Login(string email, string password)
    {
        WWWForm form = new WWWForm();// สร้าง Form กำหนดข้อมูลที่จะส่งไปที่เว็บ
        form.AddField("email", email);  // เพิ่มข้อมูลที่จะใส่ในฟอร์ม 
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(endpoint + "login.php", form))
        {
            yield return www.SendWebRequest();
            if (!www.isNetworkError || !www.isHttpError)
            {
                var result = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
                if (result != "false")
                {
                    user = JsonUtility.FromJson<User>(www.downloadHandler.text);
                    SceneManager.LoadScene("animation",LoadSceneMode.Single);
                }
                else
                {
                    AlertCore.instance.SetAlert("ชื่อผู้ใช้งานไม่ถูกต้อง");
                }
            }
            else
            {
                ConnectErr();
            }
        }
    }


    public void Register(string username, string email, string password)
    {
        StartCoroutine(_Register(username, email, password));
    }

    IEnumerator _Register(string username, string email, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        form.AddField("email", email);
        form.AddField("password", password);

        using (UnityWebRequest www = UnityWebRequest.Post(endpoint + "register.php", form))
        {
            yield return www.SendWebRequest();
            if (!www.isNetworkError || !www.isHttpError)
            {
                if(www.downloadHandler.text == "replace")
                {
                    AlertCore.instance.SetAlert("ชื่อผู้ใช้งานซ้ำ");
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                    user = JsonUtility.FromJson<User>(www.downloadHandler.text);
                    user.hight_score_game = new HighScore[0];
                    user.stages = new int[0];
                    SceneManager.LoadScene("animation", LoadSceneMode.Single);
                }
            }
            else
            {
                ConnectErr();
            }
        }
    }

    public void AddScore(int score, int stage)
    {
        StartCoroutine(_AddScore(score, stage));
    }

    IEnumerator _AddScore(int score, int stage)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", score);
        form.AddField("stage_id", stage);
        form.AddField("user_id", user.id);

        using (UnityWebRequest www = UnityWebRequest.Post(endpoint + "add-score.php", form))
        {
            yield return www.SendWebRequest(); //รอรับ-ส่งข้อมูล
            if (!www.isNetworkError || !www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
            }
            else
            {
                ConnectErr();
            }
        }
    }



    public void AddStage(int stage)
    {
        StartCoroutine(_AddStage(stage));
    }

    IEnumerator _AddStage(int stage)
    {
        WWWForm form = new WWWForm();
        form.AddField("stage_id", stage);
        form.AddField("user_id", user.id);

        using (UnityWebRequest www = UnityWebRequest.Post(endpoint + "add-stage.php", form))
        {
            yield return www.SendWebRequest();
            if (!www.isNetworkError || !www.isHttpError)
            {

            }
            else
            {
                ConnectErr();
            }
        }
    }


    public void GetUserHighScore()
    {
        StartCoroutine("_GetUserHighScore");
    }

    public class ScoreData
    {
        public HighScore[] score;
    }
    IEnumerator _GetUserHighScore()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(endpoint + "user-high-score.php?user_id=" + user.id))
        {
            yield return www.SendWebRequest();
            if (!www.isNetworkError || !www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
                user.hight_score_game = JsonUtility.FromJson<ScoreData>(www.downloadHandler.text).score;
            }
            else
            {
                ConnectErr();
            }
        }
    }

    public void GetRankingScore(int stage_id)
    {
        StartCoroutine(_GetRankingScore(stage_id));
    }

    [System.Serializable]
    public class RankingScoreData
    {
        public RankingScore[] ranking_score;
    }
    private RankingScoreData rankingScoreData;
    IEnumerator _GetRankingScore(int stage_id)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(endpoint + "score-ranking.php?stage_id=" + stage_id))
        {
            yield return www.SendWebRequest();
            if (!www.isNetworkError || !www.isHttpError)
            {
                Debug.Log(www.downloadHandler.text);
                rankingScoreData = JsonUtility.FromJson<RankingScoreData>(www.downloadHandler.text);
                RankingView.instance.SetView(rankingScoreData.ranking_score.ToList());
            }
            else
            {
                ConnectErr();
            }
        }
    }

    public static Transform ClearObjInParent(Transform transform)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        return transform;
    }

    public void ConnectErr()
    {
        Debug.Log("Can't connect server");
    }

    public void CheckCharacter(InputField input)
    {
        input.text = Regex.Replace(input.text, @"[^a-zA-Z0-9 ]", "");
    }
    public void CheckEmail(InputField input)
    {
        input.text = Regex.Replace(input.text, @"[^a-zA-Z0-9@. ]", "");
    }
}
