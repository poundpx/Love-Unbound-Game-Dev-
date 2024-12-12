using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RetryBtn()
    {
        SceneManager.LoadScene("Testing");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
