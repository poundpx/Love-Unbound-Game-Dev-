using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FootstepSystem : MonoBehaviour
{
    [Range(0, 20f)]
    public float frequency = 10.0f;
    public UnityEvent onFootStep;
    float sin;
    bool isTriggered = false;

    // Update is called once per frame
    void Update()
    {
        float InputMagnitude = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude;
        if (InputMagnitude > 0)
        {
            StartFootStep();
        }
    }

    private void StartFootStep()
    {
        sin = Mathf.Sin(Time.time * frequency);
        if (sin > .97f && isTriggered == false)
        {
            isTriggered = true;
            onFootStep.Invoke();
        }
        else if (isTriggered == true && sin < -.97f)
        {
            isTriggered = false;
        }
    }
}
