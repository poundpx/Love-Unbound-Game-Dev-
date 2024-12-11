using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteBookPickUp : MonoBehaviour
{
    //variable for notebook obj, sound and part of story
    public GameObject notebookOB;
    public GameObject pickUpText;
    public GameObject storyPanel;
    public TextMeshProUGUI storyDescription;
    public AudioSource noteBookSound;

    public bool inReach;
    public string notebookStory;

    //player object for com with notebook collect
    public GameObject Player;

    void Start()
    {
        inReach = false;
        pickUpText.SetActive(false);
        storyPanel.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            pickUpText.SetActive(true);

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            pickUpText.SetActive(false);

        }
    }


    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact"))
        {
            ShowNoteBookStory();
            notebookOB.SetActive(false);
            noteBookSound.Play();
        }
    }
    private void ShowNoteBookStory()
    {
        Player.GetComponent<ItemCollect>().Collect();
        pickUpText.SetActive(false);
        storyPanel.SetActive(true);
        storyDescription.text = notebookStory;

        //enabled cursor and pause time while story display
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void CloseStoryPanel()
    {
        storyPanel.SetActive(false);
        //disabled cursor and continue game
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

        //increase NoteBOOK item
    }
}
