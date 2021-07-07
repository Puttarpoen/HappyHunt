using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //public void GoLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    //}

    public void GoLevel1()
    {
        SceneManager.LoadScene(6,LoadSceneMode.Additive);
    }
    public void GoLevel2()
    {
        SceneManager.LoadScene(7, LoadSceneMode.Additive);
    }
    public void GoLevel3()
    {
        SceneManager.LoadScene(8, LoadSceneMode.Additive);
    }
    public void GoLevel4()
    {
        SceneManager.LoadScene(9, LoadSceneMode.Additive);
    }
    public void Gointro2_1()
    {
        SceneManager.LoadScene("intro2_1");
    }
    public void Gointro3_1()
    {
        SceneManager.LoadScene("intro3_1");
    }
    public void Gointro4_1()
    {
        SceneManager.LoadScene("intro4_1");
    }


}
