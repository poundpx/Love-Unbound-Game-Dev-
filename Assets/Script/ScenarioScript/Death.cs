using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public AudioSource laughing;
    public GameObject player;
    public GameObject jumpCam;
    
    public void death()
    {
        laughing.Play();
        jumpCam.SetActive(true);
        player.SetActive(false);

        StartCoroutine(dead());
    }

    IEnumerator dead()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Dead");
    }
}
