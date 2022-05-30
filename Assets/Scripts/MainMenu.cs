using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject howToPlay;
    
    private void Start()
    {
        howToPlay.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void HowToPlay()
    {
        howToPlay.SetActive(true);
    }
    
    public void Back()
    {
        howToPlay.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
    

}
