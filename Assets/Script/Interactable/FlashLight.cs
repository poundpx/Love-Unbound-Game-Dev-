using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flashLight;

    //Audio
    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        flashLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!on && Input.GetButtonDown("F"))
        {
            flashLight.SetActive(true);
            turnOn.Play();
            on = true;
        }
        else if (on && Input.GetButtonDown("F"))
        {
            flashLight.SetActive(false);
            turnOff.Play();
            on = false;
        }
    }
}
