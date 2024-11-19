using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    //move camera along with it position of player
    public Transform cameraPosition;

    void Update()
    {
        transform.position = cameraPosition.position;
    }
}
