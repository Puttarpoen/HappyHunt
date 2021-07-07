using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGame : MonoBehaviour
{
    public int indexGame = 0;
    public StartScene ss;
    public Button playBtn;
    public GameObject selectGameObj;
    public Text usernametext;

    private void Start()
    {
        usernametext.text = GameService.instance.user.username;
    }

    public void SelectGameIndex(int index)
    {
        if (index == 1)
        {
            indexGame = index;
            AddPlayBtn(() => { ss.NextScene(); });
            
        }
        else if (index == 2)
        {
            indexGame = index;
            AddPlayBtn(() => { ss.Gointro2_1(); });
        }
        else if (index == 3)
        {
            indexGame = index;
            AddPlayBtn(() => { ss.Gointro3_1(); });
        }
        else if (index == 4)
        {
            indexGame = index;
            AddPlayBtn(() => { ss.Gointro4_1(); });
        }
        selectGameObj.SetActive(true);
        Debug.Log("select" + indexGame);
    }

    public void AddPlayBtn(Action method)
    {
        playBtn.onClick.RemoveAllListeners();
        playBtn.onClick.AddListener(() => { method(); });
    }
}
