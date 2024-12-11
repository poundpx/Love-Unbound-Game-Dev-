using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public void RetryBtn()
    {
        SceneManager.LoadScene("Testing");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
