using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Controller : MonoBehaviour
{
    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel.ToString());
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}

