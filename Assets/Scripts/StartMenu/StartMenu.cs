using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Sprite playbtn;
    public Sprite pausebtn;

    public void Startgame()
    {
        SceneManager.LoadScene("StageOne");
    }

    public void RestarttheGame()
    {
        SceneManager.LoadScene("StartMenu");
    }


    public void Exitgame()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (Time.timeScale == 1.0f)
        {
            GameObject.Find("PlayPause").GetComponent<Image>().sprite = playbtn;
            Time.timeScale = 0.0f;
        }
        else if (Time.timeScale == 0.0f)
        {
            GameObject.Find("PlayPause").GetComponent<Image>().sprite = pausebtn;
            Time.timeScale = 1.0f;
        }
    }



}
