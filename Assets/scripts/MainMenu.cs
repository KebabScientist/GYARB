using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(string Game) //Startar spelet
    {
        SceneManager.LoadScene(Game);
    }

    public void QuitGame() //Avslutar spelet
    {
        Application.Quit();
    }

    public void Options(string Options) // går till Options
    {
        SceneManager.LoadScene(Options);
    }
}