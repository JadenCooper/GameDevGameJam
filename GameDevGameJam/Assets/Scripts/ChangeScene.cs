using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("yoimhere 1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
