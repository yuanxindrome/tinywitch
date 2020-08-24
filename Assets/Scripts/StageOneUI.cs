using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageOneUI : MonoBehaviour
{
    public Sprite playbtn;
    public Sprite pausebtn;
    public GameObject gameover;
    public GameObject gameclear;

    public void start()
    {
        gameover.SetActive(false);
    }
    public void Update()
    {

        if (Health.PlayerDead == true)
        {
            gameover.SetActive(true);
        }
        else
        {
            gameover.SetActive(false);
        }

    }


    public void MainMenu()
    {
        gameover.SetActive(false);
        gameclear.SetActive(false);
        Health.PlayerDead = false;
        SceneManager.LoadScene("StartMenu");
    }

    public void RestarttheGame()
    {
        gameover.SetActive(false);
        gameclear.SetActive(false);
        Health.PlayerDead = false;
        SceneManager.LoadScene("StageOne");
        
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
