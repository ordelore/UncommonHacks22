using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraPositions cameraPositions;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the player presses the spacebar, then we want to switch the camera position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // We want to switch the camera position
            cameraPositions.NextPosition();
        }
    }
}
