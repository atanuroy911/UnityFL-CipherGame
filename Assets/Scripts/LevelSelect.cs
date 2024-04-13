using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    //Quit Game button
    public void QuitButton()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    //Loads StegIntro level
    public void StegIntroButton()
    {
        Debug.Log("Loading level...");
        SceneManager.LoadScene("StegIntroScene");
    }

    //Loads Steg level 1
    public void StegLvl1Button()
    {
        Debug.Log("Loading level...");
        SceneManager.LoadScene("StegLvl1Scene");
    }

    //Loads CaesarIntro level
    public void CaesarIntroButton()
    {
        Debug.Log("Loading level...");
        SceneManager.LoadScene("CaesarIntroScene");
    }

    //Loads Caesar level 1
    public void CaesarLvl1Button()
    {
        Debug.Log("Loading level...");
        SceneManager.LoadScene("CaesarLvl1Scene");
    }

    //Loads VigenereIntro level
    public void VignIntroButton()
    {
        Debug.Log("Loading level...");
        SceneManager.LoadScene("VignIntroScene");
    }
}
