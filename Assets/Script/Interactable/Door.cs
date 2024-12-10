using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator door;
    public GameObject lockOB;
    public GameObject keyOB;
    public GameObject openText;
    public GameObject closeText;
    public GameObject lockedText;


    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;
    public AudioSource unlockedSound;

    private bool inReach;
    private bool doorisOpen;
    public bool unlocked;





    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach" && !doorisOpen)
        {
            inReach = true;
            openText.SetActive(true);
        }

        if (other.gameObject.tag == "Reach" && doorisOpen)
        {
            inReach = true;
            closeText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            lockedText.SetActive(false);
            closeText.SetActive(false);
        }
    }

    void Start()
    {
        inReach = false;
        doorisOpen = false;
        closeText.SetActive(false);
        openText.SetActive(false);
    }




    void Update()
    {
        if (lockOB.activeInHierarchy)
        {
            unlocked = false;
        }

        else
        {
            unlocked = true;
        }

        //unlock
        if (inReach && keyOB.activeInHierarchy && Input.GetButtonDown("Interact"))
        {
            unlockedSound.Play();
            unlocked = true;
            keyOB.SetActive(false);
            StartCoroutine(unlockDoor());
        }

        //Open Door
        if (inReach && !doorisOpen && unlocked && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", true);
            openText.SetActive(false);
            openSound.Play();
            doorisOpen = true;
        }

        //Close Door
        else if (inReach && doorisOpen && unlocked && Input.GetButtonDown("Interact"))
        {
            door.SetBool("Open", false);
            closeText.SetActive(false);
            closeSound.Play();
            doorisOpen = false;
        }

        //Lock Door
        if (inReach && !unlocked && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            lockedText.SetActive(true);
            lockedSound.Play();
        }

    }

    IEnumerator unlockDoor()
    {
        yield return new WaitForSeconds(.05f);
        {

            unlocked = true;
            lockOB.SetActive(false);
        }
    }

}
