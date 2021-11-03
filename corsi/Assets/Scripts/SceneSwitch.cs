using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    /*
     * Easy Scene Switcher index = 0 is the intro, 1 = the play scene, 2 = Outroscene
     * 
     */

    private string inputVPN = "";
    public void StartGame()
    {
        DataSaver.VPN = inputVPN;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }


    public void ReadInput(string s)
    {
        inputVPN = s;
    }

}
